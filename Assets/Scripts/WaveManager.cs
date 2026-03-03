using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

[RequireComponent(typeof(Timer))]
public class WaveManager : MonoBehaviour
{

    [SerializeField]
    private DiedMenuController diedMenu;
    [SerializeField]
    private EndMenuController endMenu;

    [SerializeField] private IntroMenuController introMenu;
    [SerializeField] private Player player;
    [SerializeField] private GameObject nextWave;

    private Timer _timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timer = GetComponent<Timer>();
        _timer.Done += OnTimerDone;
        
        Assert.IsNotNull(diedMenu, "diedMenu != null");
        Assert.IsNotNull(endMenu, "endMenu != null");
        Assert.IsNotNull(introMenu, "introMenu != null");
        Assert.IsNotNull(player, "player != null");
    }

    private void OnTimerDone(object sender, EventArgs e)
    {
        Destroy(introMenu.gameObject);
        if (!nextWave)
        {
            Destroy(diedMenu.gameObject);
            endMenu.gameObject.SetActive(true);
            endMenu.Show();
            player.Kill();
            Destroy(gameObject);
            return;
        }
        gameObject.SetActive(false);
        nextWave.gameObject.SetActive(true);
        nextWave.transform.position = player.transform.position;
        nextWave.transform.rotation = player.transform.rotation;
    }

    public void PlayerDied()
    {
        Destroy(introMenu.gameObject);
        Destroy(endMenu.gameObject);
        player.Kill();
        diedMenu.Show();
        _timer.enabled = false;
    }
}
