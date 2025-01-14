using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
     [SerializeField] protected float baseSpeed = 5f;
    protected float currentSpeed;
    
    public int extraLives {get; protected set;} = 2;

    [SerializeField] protected float damageCoolDown = 1f;
    protected float damageTimer = 0f;

    
    [SerializeField] protected float shootCoolDown = 1f;
    protected float shootTimer; 

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;
    protected Hitbox hitbox;
    
    [SerializeField] protected GameObject bullet;

    [SerializeField] protected bool moveWithRb = false; // stupid and temporary


    protected abstract void Shoot();


    protected virtual void Start()
    {
        GetDependencies();
    }

    protected virtual void Update()
    {
        damageTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if(!moveWithRb)
            Movement();
        if(Input.GetKey(KeyCode.Z))
            Shoot();
    }

    protected virtual void FixedUpdate()
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


    public void lifeRecover()
    {
        extraLives++;
    }

    public void Damage()
    {
        if(damageTimer >= damageCoolDown){
            if(extraLives <= 0)
                Destroy(gameObject);
            else
                extraLives--;
            damageTimer = 0;
            StartCoroutine(DamageFlicker());
        }
    }

    protected IEnumerator DamageFlicker(float waitTime=0.1f)
    {
        while(damageTimer < damageCoolDown)
        {
            spriteRenderer.color -= new Color(0,0,0,1);
            yield return new WaitForSeconds(waitTime);
            spriteRenderer.color += new Color(0,0,0,1);
            yield return new WaitForSeconds(waitTime);
        }
    }


    protected void GetDependencies()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        hitbox = GetComponent<Hitbox>();
        rb = GetComponent<Rigidbody2D>();
        damageTimer = damageCoolDown;
    }
}
