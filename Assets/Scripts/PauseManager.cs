using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused
    {
        get;
        private set;
    }

    private float _previousTimeScale = 1f;

    [SerializeField] private UIDocument ui;
    [SerializeField] private ThirdPersonController playerController;

    public static event EventHandler OnPause;
    public static event EventHandler OnResume;

    private bool _previousFrameGameIsPaused ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = GetComponent<UIDocument>();
        Assert.IsNotNull(ui, "ui != null");
        Assert.IsNotNull(playerController, "playerController != null");
    }

    // Update is called once per frame
    void Update()
    {
        if (_previousFrameGameIsPaused != GameIsPaused) return;
        if (!Keyboard.current.escapeKey.isPressed) return;
        
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void LateUpdate()
    {
        _previousFrameGameIsPaused = GameIsPaused;
    }

    public void Resume()
    {
        GameIsPaused = false;
        playerController.enabled = true;
        ui.enabled = GameIsPaused;
        Time.timeScale = _previousTimeScale;
        OnResume?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        GameIsPaused = true;
        playerController.enabled = false;
        ui.enabled = GameIsPaused;
        _previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        OnPause?.Invoke(this, EventArgs.Empty);
        Cursor.lockState = CursorLockMode.None;
    }
}
