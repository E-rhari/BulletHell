using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SenoidTrajectory : TrajectoryBehaviour
{
    private float time = 0;
    private Vector3 displacement = new Vector3(0,0);
    private Vector3 lastDisplacement = new Vector3(0,0);
    private Vector3 center;

    public void Start(){
        center = transform.position;
    }

    protected override void Move()
    {
        displacement = new Vector3(0,0);
        time += Time.deltaTime;

        if(direction == Direction.Horizontal)
            displacement += new Vector3(Mathf.Sin(time*speed)-lastDisplacement.x, 0);
        else if(direction == Direction.Vertical)
            displacement += new Vector3(0, Mathf.Sin(time*speed)-lastDisplacement.y);

        transform.position += displacement;
        lastDisplacement = transform.position - center;
    }
}