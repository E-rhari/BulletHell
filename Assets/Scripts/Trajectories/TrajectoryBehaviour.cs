using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrajectoryBehaviour : MonoBehaviour
{

    [SerializeField] protected float speed;
    [SerializeField] protected Direction direction;


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
