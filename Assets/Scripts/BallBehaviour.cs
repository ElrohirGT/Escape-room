using System;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class BallBehaviour : MonoBehaviour
{
    private bool _fixedDisplay = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("BallBehaviour Start");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Awake()
    {
        Debug.Log("BallBehaviour Awake");
    }

    void FixedUpdate()
    {
        if (!_fixedDisplay) return;
        _fixedDisplay = false;
        Debug.Log("BallBehaviour Fixed Update");
    }

    // It has OnEnter...OnExit too
    private void OnCollisionStay(Collision other)
    {
        Debug.Log("BallBehaviour OnCollisionStay");
    }

    // It has OnEnter..OnExit too
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("BallBehaviour OnTriggerStay");
    }
}