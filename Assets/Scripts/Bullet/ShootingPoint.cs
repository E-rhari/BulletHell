using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingPoint : MonoBehaviour
{
    [SerializeField] protected float shootCoolDown = 1f;
    protected float shootTimer; 

    
    [SerializeField] private KeyCode shootKey = KeyCode.Z;
    [SerializeField] private bool alwaysShooting = false;
    
    [SerializeField] private bool follow = false;

    [SerializeField] private GameObject baseBullet;

    [SerializeField] private int pooledAmount = 20;
    private List<GameObject> bullets;


    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
            CreateBullet();
    }


    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if(Input.GetKey(shootKey) || alwaysShooting)
            Shoot();
    }
    

    protected void Shoot()
    {
        if(shootTimer >= shootCoolDown)
        {
            GameObject bullet = GetPooledBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            shootTimer = 0;
        }
    }


    public GameObject GetPooledBullet()
    {
        foreach(GameObject obj in bullets)
            if(!obj.activeInHierarchy)
                return obj;
        GameObject newObj = CreateBullet();
        return newObj;
    }

    private GameObject CreateBullet()
    {
        GameObject obj = Instantiate(baseBullet);
        obj.SetActive(false);
        bullets.Add(obj);
        if(follow)
            obj.transform.SetParent(this.transform);
        return obj;
    }
}