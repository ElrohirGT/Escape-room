using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Assertions;

[RequireComponent(typeof(UIDocument), typeof(PauseManager))]
public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private UIDocument ui;
    [SerializeField] private PauseManager pauseManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui ??= GetComponent<UIDocument>();
        Assert.IsNotNull(ui, nameof(ui) + " is null!");

        pauseManager ??= GetComponent<PauseManager>();
        Assert.IsNotNull(pauseManager, "pauseManager != null");

        var btn = ui.rootVisualElement.Q<UnityEngine.UIElements.Button>("btnContinue");
        btn.RegisterCallback<ClickEvent>(evt => pauseManager.Resume());

        btn = ui.rootVisualElement.Q<UnityEngine.UIElements.Button>("btnQuit");
        btn.RegisterCallback<ClickEvent>(BtnQuitClicked);
    }

    private void BtnQuitClicked(ClickEvent evt)
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(0);
#endif
    }
}