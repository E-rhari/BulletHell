using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PlayerCharacter player;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerCharacter>();
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

    
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Damage" || other.gameObject.GetComponent<Damage>())
            player.Damage();
    }
}
