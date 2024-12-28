using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
     [SerializeField] protected float baseSpeed = 5f;
    protected float currentSpeed;
    
    public int extraLives {get; protected set;} = 2;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;
    protected Hitbox hitbox;

    [SerializeField] protected bool moveWithRb = false; // stupid and temporary


    protected abstract void Shoot();


    void Start()
    {
        GetPendentComponents();
    }

    void Update()
    {
        if(!moveWithRb)
            Movement();
    }

    void FixedUpdate()
    {
        if(moveWithRb)
            RbMovement();
    }

    /// <summary>
    ///     Defines the hability of the object to move according to player input.
    ///     Moves using the transform component, not the rigidbody. Should be ran
    ///     in Update();
    /// </summary>
    protected void Movement()
    {
        Focus();
        Vector3 displacement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*currentSpeed;
        transform.Translate(displacement*Time.deltaTime); 
    }

    /// <summary>
    ///     Defines the hability of the object to move according to player input.
    ///     Moves using the RigidBody2D component. Should be ran in FixedUpdate();
    /// </summary>
    protected void RbMovement()
    {
        Focus();
        Vector2 displacement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*currentSpeed;
        rb.MovePosition(rb.position + displacement*Time.fixedDeltaTime);
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
        hitbox = GetComponent<Hitbox>();
        rb = GetComponent<Rigidbody2D>();
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
