using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TrajectoryBehaviour : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected Direction direction;


    protected abstract void Move();


    public virtual void Start()
    {
    }

    protected virtual void Update()
    {
        Move();
    }


    
    protected enum Direction{
        Vertical,
        Horizontal,
        All
    }
}
