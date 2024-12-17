using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
     [SerializeField] protected float baseSpeed = 5f;
    protected float currentSpeed;
    protected SpriteRenderer spriteRenderer;
    protected Hitbox hitbox;
    protected int extraLives = 2;


    protected abstract void Shoot();


    void Start()
    {
        GetPendentComponents();
    }

    void Update()
    {
        Movement();
    }


    protected void Movement()
    {
        Focus();
        Vector3 displacement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*currentSpeed;
        transform.Translate(displacement*Time.deltaTime); 
    }

    protected void Focus()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = baseSpeed/2;
            hitbox.Show();
        }
        else{
            currentSpeed = baseSpeed;
            hitbox.Hide();
        }
    }

    protected void GetPendentComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitbox = GetComponentInChildren<Hitbox>();
    }

    public void damage()
    {
        if(extraLives <= 0)
            Destroy(gameObject);
        else
            extraLives--;
    }

    public void lifeRecover()
    {
        extraLives++;
    }
}
