using UnityEngine;
using Zenject;

public class Cart : MonoBehaviour
{
    #region INJECTIONS
    [Inject]
    PauseManager pause;
    #endregion

    #region PARAMETERS
    [Header("Track Data")]
    public Track firstTrack;
    Track currentTrack;

    [Header("Cart Parameters")]
    public float horizontalVelocity;
    public Transform sprite;

    [Header("Jumping")]
    public float jumpHeight;
    public float jumpTime;

    #endregion

    #region MOVING_METHODS
    void MoveAlong(Track track, float distance)
    {
        Vector3 newPosition = transform.position;
        float verticalShift = Mathf.Min(Mathf.Abs(transform.position.y - currentTrack.transform.position.y), distance);
        if (!isJumping)
        {
            bool shiftDir = transform.position.y > currentTrack.transform.position.y;
            newPosition.y += (shiftDir ? -1 : 1) * verticalShift / Mathf.Sqrt(2);

            // Rotate if
            if (Mathf.Abs(verticalShift) == distance)
            {
                sprite.rotation = Quaternion.Euler(0, 0, (shiftDir ? -1 : 1) * 45);
                sprite.localPosition = new Vector2((shiftDir ? 0.8f : 0.3f), 0.25f);
            }
            else
            {
                sprite.rotation = Quaternion.Euler(0, 0, 0);
                sprite.localPosition = new Vector2(0, 0.25f);
            }
        }
        else
        {
            newPosition.y += Jumping() * Time.fixedDeltaTime;
            if (newPosition.y <= track.transform.position.y)
            {
                newPosition.y = track.transform.position.y;
                isJumping = false;
            }
        }
        newPosition.x += distance  / ((verticalShift != 0) ? Mathf.Sqrt(2) : 1);
        transform.position = newPosition;
    }
    #endregion

    #region JUMPING
    public bool isJumping = false;
    public void Jump()
    {
        if (!isJumping && !pause.IsPaused)
        {
            isJumping = true;
            jumpVelocity = JumpForce;
        }
    }

    float JumpForce
    {
        get { return Gravity * jumpTime; }
    }

    float Gravity
    {
        get { return (2 * jumpHeight) / (jumpTime * jumpTime); }
    }

    float jumpVelocity;

    float Jumping()
    {
        jumpVelocity -= Gravity * Time.fixedDeltaTime;
        return jumpVelocity;
    }
    #endregion

    #region SWITCHING
    public void SwitchTrack(Track newTrack)
    {
        currentTrack = newTrack;
    }
    #endregion

    #region MONOBEHAVIOUR_METHODS
    void Awake()
    {
        currentTrack = firstTrack;
    }

    void FixedUpdate()
    {
        // Move along current track
        if (!pause.IsPaused)
            MoveAlong(currentTrack, horizontalVelocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    #endregion
}
