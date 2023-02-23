using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    [SerializeField] private float bounceForce;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weakpoint")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
