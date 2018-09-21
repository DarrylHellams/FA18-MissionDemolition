﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public GameObject POI; //the static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; //the desired Z pos of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        //if there's only one line following an if, it doesn't need braces
        if (POI == null) return; //return if there is no poi

        //get the position of the poi
        Vector3 destination = POI.transform.position;

        //Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        //interpolate from the current camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);

        //force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;

        //set the camera to the destination
        transform.position = destination;

        //set the orthpgraphic size of the camera to keep ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
