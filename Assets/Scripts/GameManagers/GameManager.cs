using Zenject;
using UnityEngine;

public class GameManager : ITickable
{
    [Inject]
    PauseManager pause;

    public int points = 0;

    float seconds = 0;

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
        Application.LoadLevel(Application.loadedLevel);
    }
}