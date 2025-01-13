using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrajectory : TrajectoryBehaviour
{
    protected override void Move()
    {
        Vector3 trajectory = new Vector3(speedX*Time.deltaTime, speedY*Time.deltaTime);
        transform.Translate(trajectory);
    }
}