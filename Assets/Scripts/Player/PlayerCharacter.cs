using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
     [SerializeField] protected float baseSpeed = 5f;
    private float currentSpeed;
    // protected SpriteRenderer spriteRenderer;
    protected Hitbox hitbox;


    protected abstract void Shoot();


    protected void Movement(){
        Focus();
        Vector3 displacement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*currentSpeed;
        transform.Translate(displacement*Time.deltaTime); 
    }

    protected void Focus(){
        if(Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = baseSpeed/2;
            hitbox.Show();
        }
        else{
            currentSpeed = baseSpeed;
            hitbox.Hide();
        }
    }

    protected void GetPendentComponents(){
        // spriteRenderer = GetComponent<SpriteRenderer>();
        hitbox = GetComponentInChildren<Hitbox>();
    }
}
