using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static event Action CoinPickedUp;
    public static void TriggerCoinPickedUp()
    {
        CoinPickedUp?.Invoke();
    }

    public static event Action<int> DamageTaken;
    public static void TriggerDamageTaken(int damage)
    {
        DamageTaken?.Invoke(damage);
    }

    public static event Action NightCubePickedUp;
    public static void TriggerNightCubePickedUp()
    {
        NightCubePickedUp?.Invoke();
    }
    
    
    public static event Action LightCubePickedUp;
    public static void TriggerLightCubePickedUp()
    {
        LightCubePickedUp?.Invoke();
    }
    
    public static event Action CatPickedUp;
    public static void TriggerCatPickedUp()
    {
        CatPickedUp?.Invoke();
    }

    public static event Action<PickUpObj> InventoryItemPickedUp;

    public static void TriggerInventoryItemPickedUp(PickUpObj item)
    {
        InventoryItemPickedUp?.Invoke(item);
    }
}