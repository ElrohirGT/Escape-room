using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private CageManager cage;

    [SerializeField] private bool isPressed;
    public bool IsPressed => isPressed;

    [SerializeField] private float buttonDelta = 0.4f;

    private BoxCollider _collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        Utils.CrashIfNull(cage, "The cage can't be null!");
    }

    private void OnTriggerEnter(Collider other)
    {
        var delta = Vector3.down * buttonDelta;
        isPressed = true;
        transform.position +=  delta;
        _collider.size -= 2*delta;
        cage.LiftCage();
    }

    private void OnTriggerStay(Collider other)
    {
        cage.LiftCage();
    }

    private void OnTriggerExit(Collider other)
    {
        var delta = Vector3.up * buttonDelta;
        isPressed = false;
        transform.position +=  delta;
        _collider.size -= 2 * delta;
        cage.DropCage();
    }
}
