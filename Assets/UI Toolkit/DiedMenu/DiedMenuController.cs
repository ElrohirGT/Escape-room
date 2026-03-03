using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class DiedMenuController : MonoBehaviour
{
    [SerializeField] private UIDocument ui;
    [SerializeField] private AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ui ??= GetComponent<UIDocument>();
        Assert.IsNotNull(ui, nameof(ui) + " is null!");
        
        audioSource ??= GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource, "audioSource != null");

        Hide();

        var btn = ui.rootVisualElement.Q<UnityEngine.UIElements.Button>("btnRetry");
        btn.RegisterCallback<ClickEvent>(evt =>
        {
            SceneManager.LoadScene("Navigation");
        });

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

    public void Hide()
    {
        ui.rootVisualElement.style.display = DisplayStyle.None;
        audioSource.Stop();
    }

    public void Show()
    {
        Cursor.lockState = CursorLockMode.None;
        ui.rootVisualElement.style.display = DisplayStyle.Flex;
        audioSource.Play();
    }
}
