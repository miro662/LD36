using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour
{
    #region PARAMETERS
    [Header("Track Data")]
    public Track firstTrack;
    Track currentTrack;

    [Header("Cart Parameters")]
    public float horizontalVelocity;

    [Header("Jumping")]
    public float jumpHeight;
    public float jumpTime;
    #endregion

    #region MOVING_METHODS
    void MoveAlong(Track track, float distance)
    {
        Vector3 newPosition = transform.position;
        if (!isJumping)
        {
            newPosition.y = track.transform.position.y; // set position to current track position
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
        newPosition.x += distance;
        transform.position = newPosition;
    }
    #endregion

    #region JUMPING
    public bool isJumping = false;
    public void Jump()
    {
        if (!isJumping)
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
