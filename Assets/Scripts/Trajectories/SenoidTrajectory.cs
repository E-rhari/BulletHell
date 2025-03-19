using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SenoidTrajectory : TrajectoryBehaviour
{
    private float time = 0;
    private Vector3 displacement = new Vector3(0,0);
    private Vector3 relativeCenter = new Vector3(0,0);

    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float lenght = 1f;
    [SerializeField] private float startDisplacement = 0f;
    [SerializeField] private float positionDisplacement = 0f;
    private float sinPosition;

    private Vector3 center;


    public override void Start()
    {
        center = transform.position;
    }


    public void OnEnable()
    {
        time = 0;
        center = transform.position;
        relativeCenter = new Vector3(0,0);
    }


    protected override void Move()
    {
        displacement = new Vector3(0,0);
        time += Time.deltaTime;
        center = transform.position - relativeCenter;

        sinPosition = amplitude * Mathf.Sin(lenght*time*speed + startDisplacement) + positionDisplacement;
        if(direction == Direction.Horizontal || direction == Direction.All)
            displacement += new Vector3(sinPosition-relativeCenter.x, 0);
        else if(direction == Direction.Vertical || direction == Direction.All)
            displacement += new Vector3(0, sinPosition-relativeCenter.y);

        transform.position += displacement;
        relativeCenter = transform.position - center;
    }
}