using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Animator anim;
    Rigidbody2D rigid;
    [SerializeField] private float startingHealth;
    public float currentHealth { get; set; }

    [SerializeField] private float iframeDuration;
    [SerializeField] private float numberOfflashes;
    private SpriteRenderer spriteRenderer;


    //[SerializeField] private Behaviour[] components;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            SoundManager.Instance.PlayHurtSound();
            anim.SetTrigger("Hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            SoundManager.Instance.PlayDeathSound();
            //foreach(Behaviour component in components)
            //    component.enabled = false
            rigid.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Death");
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfflashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframeDuration / (numberOfflashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iframeDuration / (numberOfflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);    
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    public void Respawn()
    {
        AddHealth(startingHealth);
        anim.ResetTrigger("Death");
        anim.Play("PlayerIdle");
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
