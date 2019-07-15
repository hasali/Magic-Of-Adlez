using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public GameObject goalTarget;       
    public GameObject lookAtTarget;

    public float hysteresisConst;

    // Use this for initialization
    void Start()
    {
        //hysteresisConst = 0.15f;
    }

    // use hysteresis for smooth camera movement
    public void CameraLogicUpdate()
    {
        this.transform.position += hysteresisConst * (goalTarget.transform.position - this.transform.position);
        this.transform.LookAt(lookAtTarget.transform);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraLogicUpdate();       
    }
}