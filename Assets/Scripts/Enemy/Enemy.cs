using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 100;

    [SerializeField] protected float Speed;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch");
        if(other.gameObject.GetComponent<Damage>())
            health -= other.gameObject.GetComponent<Damage>().damage;
        if(health <= 0)
            Die();
    }


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    protected void Die()
    {
        Destroy(this.gameObject);
    }
}
