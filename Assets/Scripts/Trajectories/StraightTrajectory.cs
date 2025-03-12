using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrajectory : TrajectoryBehaviour
{
    protected override void Move()
    {
        Vector3 displacement = new Vector3(0,0,0);

        if(direction == Direction.Horizontal || direction == Direction.All)
            displacement = new Vector3(speed*Time.deltaTime, 0);
        else if(direction == Direction.Vertical || direction == Direction.All)
            displacement = new Vector3(0, speed*Time.deltaTime);

        transform.Translate(displacement);
    }
}