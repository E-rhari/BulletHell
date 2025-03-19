using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Damage
{
     void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainCamera" || other.gameObject.GetComponent<Camera>())
            this.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Enemy>())
            this.gameObject.SetActive(false);
    }
}