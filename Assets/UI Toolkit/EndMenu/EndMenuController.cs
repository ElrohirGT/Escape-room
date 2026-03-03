using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Assertions;
using Cursor = UnityEngine.Cursor;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private UIDocument ui;
    [SerializeField] private string sceneToPlay = "Rooms";
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool startHidden;

    private AsyncOperation _gameSceneLoadOp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadRoomsAsync());
        
        ui ??= GetComponent<UIDocument>();
        Assert.IsNotNull(ui, nameof(ui) + " is null!");
        
        audioSource ??= GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource, "audioSource != null");
        
        if (startHidden)
        {
            Hide();
        }

        var btn = ui.rootVisualElement.Q<UnityEngine.UIElements.Button>("btnPlay");
        btn.RegisterCallback<ClickEvent>(evt => _gameSceneLoadOp.allowSceneActivation = true);

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

    IEnumerator LoadRoomsAsync()
    {
        _gameSceneLoadOp = SceneManager.LoadSceneAsync(sceneToPlay);
        Assert.IsNotNull(_gameSceneLoadOp, nameof(_gameSceneLoadOp) + " is null!");
        _gameSceneLoadOp.allowSceneActivation = false;

        while (!_gameSceneLoadOp.isDone)
        {
            yield return null;
        }

        Debug.Log("Game Scene loaded!");
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