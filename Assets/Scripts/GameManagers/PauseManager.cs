using Zenject;

public class PauseManager: IInitializable
{
    public bool IsPaused { get; set; }

    void IInitializable.Initialize()
    {
        IsPaused = false;
    }
}