using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

[RequireComponent(typeof(Timer))]
public class IntroMenuController : MonoBehaviour
{
    [SerializeField] private UIDocument ui;
    [SerializeField] private string title;

    private Timer _displayTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui ??= GetComponent<UIDocument>();
        
        Assert.IsNotNull(ui, "ui != null");
        Assert.IsNotNull(title, "title != null");

        var label = ui.rootVisualElement.Q<UnityEngine.UIElements.Label>("title");
        label.text = title;

        _displayTimer = GetComponent<Timer>();
        _displayTimer.Done += OnDoneDisplayTimer;
    }

    private void OnDoneDisplayTimer(object sender, EventArgs e)
    {
        ui.enabled = false;
    }
}
