using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    public Camera mainCam;

	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
        // healthbar always faces camera
        this.transform.LookAt(mainCam.transform);
    }
}
