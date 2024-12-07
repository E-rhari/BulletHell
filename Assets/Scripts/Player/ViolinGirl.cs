using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViolinGirl : PlayerCharacter
{
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        GetPendentComponents();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    protected override void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + (spriteRenderer.bounds.size.y/2) + (bullet.GetComponent<SpriteRenderer>().bounds.size.y/2)), new Quaternion(0,0,0,0));
    }
}
