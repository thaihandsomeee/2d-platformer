using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] float distance;
    private bool isFalling = false;
    [SerializeField] private float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    rb.gravityScale = 4;
                    isFalling = true;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * distance);
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
