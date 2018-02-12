using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBounds : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraFollow theCamera;

    void Start()   //Used to change the cameras bounding box
    {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraFollow>();
        theCamera.SetBounds(bounds);
    }

    

}
