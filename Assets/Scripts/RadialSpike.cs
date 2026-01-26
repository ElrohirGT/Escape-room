using System;
using UnityEngine;

public class RadialSpike : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private Transform spike;
    
    [SerializeField] private float radius;
    [SerializeField] private float rotationSpeed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Utils.CrashIfNull(center, "Center can't be null!");
        Utils.CrashIfNull(spike, "Spike can't be null!");
    }

    private void Update()
    {
         center.Rotate(Vector3.up, rotationSpeed*Time.deltaTime, Space.World);
         spike.position = center.position + center.forward * radius;
         spike.RotateAround(center.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
