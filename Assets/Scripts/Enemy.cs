using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    protected IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerMovement.Instance.KBCounter = PlayerMovement.Instance.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                PlayerMovement.Instance.KnockFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                PlayerMovement.Instance.KnockFromRight = false;
            }          
            collision.GetComponent<Health>().TakeDamage(damage);
            collision.enabled = false;
            yield return new WaitForSeconds(1);
            collision.enabled = true;
        }
    }
}
