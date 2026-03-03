using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private UIDocument ui;

    private Label _label;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui ??= GetComponent<UIDocument>();
        
        Assert.IsNotNull(timer, "timer != null");
        Assert.IsNotNull(ui, "ui != null");

        _label = ui.rootVisualElement.Q<Label>("title");
        _label.text = timer.Duration.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        _label.text = timer.Duration > 0 ? timer.Duration.ToString("F2") : "00.00";
    }
}
