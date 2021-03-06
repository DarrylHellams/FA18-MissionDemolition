﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    //a static field accessible by code anywhere
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
       //when the trigger is hit by something
       //check to see if its a projectile
       if (other.gameObject.tag == "Projectile")
        {
            //if so, set goalMet to true
            Goal.goalMet = true;
            //also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
