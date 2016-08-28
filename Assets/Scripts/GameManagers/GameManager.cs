using Zenject;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : ITickable, IInitializable
{
    [Inject]
    PauseManager pause;
    [Inject]
    GameManager manager;

    public int points = 0;

    float seconds = 0;

    GameObject deathScreen;

    void IInitializable.Initialize()
    {
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.SetActive(false);
    }

    void ITickable.Tick()
    {
        seconds += Time.deltaTime;
        if (seconds > 1)
        {
            seconds -= 1f;
            points += 1;
        }
    }

    public void Death()
    {
        deathScreen.SetActive(true);
        GameObject.Find("DPoints").GetComponent<Text>().text = manager.points + "";
    }
}