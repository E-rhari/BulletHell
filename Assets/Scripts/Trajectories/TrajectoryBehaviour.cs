using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TrajectoryBehaviour : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Direction direction;


    protected abstract void Move();


    protected virtual void Update()
    {
        Move();
    }


    
    protected enum Direction{
        Vertical,
        Horizontal
    }
}
