using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Steering : MonoBehaviour
{
    #region COMPONENTS
    SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion

    #region PARAMETERS
    public Option[] options;
    public int startOption = 0;
    #endregion

    #region TYPES
    [System.Serializable]
    public struct Option
    {
        public Track newTrack;
        public Sprite sprite;
    }
    #endregion

    #region SWITCHING
    int currentOption;

    public Option CurrentOption
    {
        get { return options[currentOption]; }
    }

    public void SetOption(int id)
    {
        currentOption = id;
        _spriteRenderer.sprite = CurrentOption.sprite;
    }
    #endregion

    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        SetOption(startOption);
    }

    void OnMouseDown()
    {
        SetOption(currentOption == (options.Length - 1) ? 0 : currentOption + 1);
    }
    #endregion
}
