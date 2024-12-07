using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            Show();
        else
            Hide();
    }

    public void Hide(){
        spriteRenderer.color *= new Color(1,1,1,0);
    }

    public void Show(){
        spriteRenderer.color += new Color(0,0,0,1);
    }
}
