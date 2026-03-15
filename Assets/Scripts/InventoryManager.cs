using System;
using UnityEngine;
using UnityEngine.Assertions;

public class InventoryManager : MonoBehaviour
{
    public PickUpObj nightCubeInfo;
    public PickUpObj lightCubeInfo;
    public PickUpObj catInfo;

    private void Start()
    {
        Assert.IsNotNull(nightCubeInfo, "nightCubeInfo != null");
        Assert.IsNotNull(lightCubeInfo, "lightCubeInfo != null");
        Assert.IsNotNull(catInfo, "cat != null");
    }

    private void OnEnable()
    {
        EventBus.NightCubePickedUp += EventBusOnNightCubePickedUp;
        EventBus.LightCubePickedUp += EventBusOnLightCubePickedUp;
        EventBus.CatPickedUp += EventBusOnCatPickedUp;
    }


    private void OnDisable()
    {
        EventBus.NightCubePickedUp -= EventBusOnNightCubePickedUp;
        EventBus.LightCubePickedUp -= EventBusOnLightCubePickedUp;
        EventBus.CatPickedUp -= EventBusOnCatPickedUp;
    }
    
    private void EventBusOnCatPickedUp()
    {
        EventBus.TriggerInventoryItemPickedUp(catInfo);
    }

    private void EventBusOnNightCubePickedUp()
    {
        EventBus.TriggerInventoryItemPickedUp(nightCubeInfo);
    }
    
    private void EventBusOnLightCubePickedUp()
    {
        EventBus.TriggerInventoryItemPickedUp(lightCubeInfo);
    }
}
