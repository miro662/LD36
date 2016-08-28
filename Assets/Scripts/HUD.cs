using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HUD : MonoBehaviour
{
    [Inject]
    PauseManager pause;

    [Inject]
    GameManager game;

    public Text points;

    public void TogglePause()
    {
        pause.IsPaused = !pause.IsPaused;
    }

    void Update()
    {
        points.text = "" + game.points;
    }
}
