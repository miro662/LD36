using UnityEngine;
using System.Collections;

public class DeathHUD : MonoBehaviour
{
    public void Restart()
    {
        print("A");
        Application.LoadLevel(Application.loadedLevel);
    }
}
