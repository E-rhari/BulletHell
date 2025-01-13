using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SenoidTrajectory : TrajectoryBehaviour
{
    [SerializeField] Direction direction;
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

        if(speedX != 0)
            displacement += new Vector3(Mathf.Sin(time*speedX)-lastDisplacement.x, 0);
        if(speedY != 0)
            displacement += new Vector3(0, Mathf.Sin(time*speedY)-lastDisplacement.y);

        // transform.Translate(displacement);
        transform.position += displacement;
        lastDisplacement = transform.position - center;

        // transform.Translate(trajectory);
    }
}