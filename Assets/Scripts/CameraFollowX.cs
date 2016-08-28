using UnityEngine;
using System.Collections;

public class CameraFollowX : MonoBehaviour {
    public Transform follow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.x = follow.position.x;
        transform.position = newPos;
	}
}
