using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour
{
    #region PARAMETERS

    [Header("Track Data")]
    public Track[] tracks;
    public int firstTrack;
    int currentTrack;

    [Header("Cart Parameters")]
    public float horizontalVelocity;
    public Vector3 cartOffset;

    #endregion


    #region MOVING_METHODS
    
    void MoveAlong(Track track, float distance)
    {
        Vector3 newPosition = transform.position;
        newPosition.y = track.transform.position.y; // set position to current track position
        newPosition.x += distance;
        newPosition += cartOffset;
        transform.position = newPosition;
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
        MoveAlong(tracks[currentTrack], horizontalVelocity * Time.fixedDeltaTime);
    }

    #endregion
}
