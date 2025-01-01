using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViolinGirl : PlayerCharacter
{
    protected override void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + (spriteRenderer.bounds.size.y/2) + (bullet.GetComponent<SpriteRenderer>().bounds.size.y/2)), new Quaternion(0,0,0,0));
        Movement();
    }
}
