using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrajectoryBehaviour : MonoBehaviour
{

    [SerializeField] protected float speedX;
    [SerializeField] protected float speedY;


    protected abstract void Move();


    void Update()
    {
        Move();
    }

    
    protected enum Direction{
        Vertical,
        Horizontal
    }
}
