using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target; // Main plkayer the camaera follows
    Camera mycam;            //Camera object

    private BoxCollider2D boundBox;   //Bounding box the camera is allowed inside
    private Vector3 minBounds;        //Minimum zoom
    private Vector3 maxBounds;        //Maximum zoom
    private Camera theCamera;        // secondary camera
    private float halfHeight;        
    private float halfWidth;

    // On launch, Gets the camera object and assigns global variables
    void Start () {  
        mycam = GetComponent<Camera>();
        halfHeight = mycam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }
	
	// Once per frame, Moves camera according to the player movement as long as player is with the camera bounding box
	void Update () {
        mycam.orthographicSize = (Screen.height / 100f) / 1f;

        if (target) {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f) + new Vector3(0,0,-10);
        }

        float clampedX = Mathf.Clamp(this.transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(this.transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY,transform.position.z);

    }

    public void SetBounds(BoxCollider2D newBounds) {
        boundBox = newBounds;
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }
}
