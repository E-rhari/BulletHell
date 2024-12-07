using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
     [SerializeField] protected float baseSpeed = 5f;
    private float currentSpeed;
    // protected SpriteRenderer spriteRenderer;


    protected abstract void Shoot();


    protected void Movement(){
        Vector3 displacement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*currentSpeed;
        transform.Translate(displacement*Time.deltaTime); 
    }

    }

    protected void GetPendentComponents(){
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
