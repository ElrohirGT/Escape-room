using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Assertions;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private UIDocument ui;

    private AsyncOperation _gameSceneLoadOp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadRoomsAsync());

        ui ??= GetComponent<UIDocument>();
        Assert.IsNotNull(ui, nameof(ui) + " is null!");

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
        _gameSceneLoadOp = SceneManager.LoadSceneAsync("Rooms");
        Assert.IsNotNull(_gameSceneLoadOp, nameof(_gameSceneLoadOp) + " is null!");
        _gameSceneLoadOp.allowSceneActivation = false;

        while (!_gameSceneLoadOp.isDone)
        {
            yield return null;
        }

        Debug.Log("Game Scene loaded!");
    }
}