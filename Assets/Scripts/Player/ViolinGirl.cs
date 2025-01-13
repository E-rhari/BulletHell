using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViolinGirl : PlayerCharacter
{
    protected override void Shoot()
    {
        if(shootTimer >= shootCoolDown){
            Instantiate(bullet, transform.position, new Quaternion(0,0,0,0));
            shootTimer = 0f;
        }
    }
}
