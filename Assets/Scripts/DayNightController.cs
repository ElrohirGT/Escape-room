using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Light))]
public class DayNightController : MonoBehaviour
{
    private Light _sun;
    [SerializeField]
    private float dayDurationSeconds = 120f; // A full day in 120 real-world seconds
    
    [SerializeField]
    private Gradient ambientColor;
    [SerializeField]
    private Gradient fogColor;
    [SerializeField]
    private float timeOfDay; // 0 (midnight) to 1 (next midnight)

    [SerializeField]
    private float targetAngle = 30;
    
    [SerializeField]
    private bool shouldCycle;

    private void OnEnable()
    {
        EventBus.NightCubePickedUp += MakeNight;
        EventBus.LightCubePickedUp += MakeDay;
    }
    
    private void OnDisable()
    {
        EventBus.NightCubePickedUp -= MakeNight;
        EventBus.LightCubePickedUp -= MakeDay;
    }

    private Vector3 _rotationAxis;
    private Quaternion _rotationStart;

    private void Start()
    {
        _sun = GetComponent<Light>();
        _rotationAxis = transform.right;
    }

    private void Update()
    {
        if (shouldCycle)
        {
            DoDayNightCycle();
        }
    }

    private void MakeNight()
    {
        timeOfDay = 0;
        targetAngle = 270;
        shouldCycle = true;
        _rotationStart = _sun.transform.rotation;
    }

    private void MakeDay()
    {
        timeOfDay = 0;
        targetAngle = 30;
        shouldCycle = true;
        _rotationStart = _sun.transform.rotation;
    }

    private void DoDayNightCycle()
    {
        // Calculate rotation speed (360 degrees over the total duration)
        // float rotationSpeed = 360f / dayDurationSeconds;
        
        timeOfDay += Time.deltaTime / dayDurationSeconds;
        if (timeOfDay > 1f)
        {
            print("Turning off cycle!");
            timeOfDay = 0f;
            shouldCycle = false;
            return;
        }
        
        // Rotate around the world's X-axis
        var target = Quaternion.AngleAxis(targetAngle, _rotationAxis);
        _sun.transform.rotation = Quaternion.Lerp(_rotationStart, target, timeOfDay);
        
        RenderSettings.ambientLight = ambientColor.Evaluate(timeOfDay);
        RenderSettings.fogColor = fogColor.Evaluate(timeOfDay);

        DynamicGI.UpdateEnvironment(); // Essential for accurate lighting updates
    }
}
