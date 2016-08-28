using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Steering : MonoBehaviour
{
    #region COMPONENTS
    SpriteRenderer _spriteRenderer;
    Collider2D _collider2d;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2d = GetComponent<Collider2D>();
    }
    public AudioClip steeringSound;
    #endregion

    #region PARAMETERS
    public Option[] options;
    public int startOption = 0;
    public LayerMask player;
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
        AudioSource source = GetComponent<AudioSource>();
        {
            if (source != null)
            {
                source.PlayOneShot(steeringSound);
            }
        }
    }

    bool locked = false;

    void Update()
    {
        if (!locked)
        {
            // Try to "catch" player
            RaycastHit2D hit = Physics2D.BoxCast(_collider2d.bounds.center, _collider2d.bounds.size, 0, Vector2.zero, 0, player);
            if (hit.collider != null)
            {
                if (!hit.collider.GetComponent<Cart>().isJumping)
                    hit.collider.GetComponent<Cart>().SwitchTrack(CurrentOption.newTrack);
            }
        }
    }
    #endregion
}
