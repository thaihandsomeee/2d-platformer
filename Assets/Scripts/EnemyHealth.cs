using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private int enemyHP;
    [SerializeField] private int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        currentHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            anim.SetTrigger("Death");        
            Destroy(transform.parent.gameObject, 0.1f);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
