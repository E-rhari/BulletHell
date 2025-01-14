using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrajectory : TrajectoryBehaviour
{
    protected override void Move()
    {
        Vector3 displacement = new Vector3(0,0,0);

        if(direction == Direction.Horizontal)
            displacement = new Vector3(speed*Time.deltaTime, 0);
        else if(direction == Direction.Vertical)
            displacement = new Vector3(0, speed*Time.deltaTime);

        transform.position += displacement;
    }
}