using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainCamera" || other.gameObject.GetComponent<Camera>())
            this.gameObject.SetActive(false);
    }
}