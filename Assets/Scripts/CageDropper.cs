using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CageDropper : MonoBehaviour
{
    [SerializeField] private CageManager cage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Utils.CrashIfNull(cage, "Cage can't be null!");
    }

    private void OnTriggerEnter(Collider other)
    {
        cage.DropCage();
    }
}
