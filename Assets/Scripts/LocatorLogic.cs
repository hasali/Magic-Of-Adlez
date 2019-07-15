using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatorLogic : MonoBehaviour {

    public GameObject goalTarget;
    public GameObject lookAtObj;

    public float h;
    public float v;

    float hPanSpeed;
    float vPanSpeed;
    
    float maxVPan;
    float resetSpeed;
    Vector3 targetDir;
    bool resetCam;

    // Use this for initialization
    void Start () {
        hPanSpeed = 100.0f;
        vPanSpeed = 2.0f;
        maxVPan = 5.0f;
        resetSpeed = 5.0f;
        targetDir = transform.forward;
        resetCam = false;
    }
	
    public void LocatorLogicUpdate()
    {
        this.transform.position = goalTarget.transform.position;

        h = Input.GetAxis("CameraHorizontalAxis");
        v = Input.GetAxis("CameraVerticalAxis");

        if (Input.GetKeyUp(KeyCode.R))
        {
            //center camera behind player
            targetDir = goalTarget.transform.forward;
            resetCam = true;
        }
        while (resetCam) {
            if (this.transform.forward != targetDir) {
                this.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(this.transform.forward, targetDir, resetSpeed * Time.deltaTime, 1.0f));
            } else
            {
                resetCam = false;
            }
        }

        this.transform.Rotate(Vector3.up, h * hPanSpeed * Time.deltaTime);
        if (lookAtObj != null)
        {
            if (Mathf.Abs((this.transform.position -
                (lookAtObj.transform.position +
                Vector3.up * v * vPanSpeed * Time.deltaTime)).y) < maxVPan)
            {
                lookAtObj.transform.position += Vector3.up * v * vPanSpeed * Time.deltaTime;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        LocatorLogicUpdate();
	}
}
