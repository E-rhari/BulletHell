using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    
    [SerializeField] protected float coolDown = 3f;
    protected float timer = 0f;

    [SerializeField] protected int amount = 1;
    protected int amountGenerated = 0;

    [SerializeField] protected GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= coolDown)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
            amountGenerated++;
        }
        if(amountGenerated >= amount)
            Destroy(this.gameObject);
    }
}
