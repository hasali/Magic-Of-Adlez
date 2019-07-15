using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{

    public GameObject targetObj;
    public Vector3 velocity;
    public float maxSteerSpeed;
    public float maxMoveSpeed;

    public float groundHeight;

    public enum eSteeringBehavior
    {
        invalid = -1,
        idle = 0,
        seek = 1,
        flee = 2
    };

    public eSteeringBehavior steeringBehavior;

    public void SetSteeringBehaviour(int newBehaviour)
    {
        steeringBehavior = (eSteeringBehavior)newBehaviour;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void AILogicUpdate()
    {
        switch (steeringBehavior)
        {
            case (eSteeringBehavior.seek):
                {
                    //
                    UpdateSeek();
                    break;
                }
            case (eSteeringBehavior.flee):
                {
                    //
                    UpdateFlee();
                    break;
                }

        }
    }

    private void UpdateFlee()
    {
        //
        //	seek, seeks to make a b-line woards to player
        //	// get the vector from where we are, to where we want to go...
        Vector3 vSteer = -1.0f * (targetObj.transform.position - this.transform.position);
        vSteer.Normalize();
        vSteer = vSteer * maxSteerSpeed;

        // vSteer is the max change in velocity we can
        // apply to the character, to steer it in the right direction
        // towards the target

        // here, we are actually just using the steering vector as the speed
        velocity += vSteer; // this cant be right can it?
        velocity.Normalize();
        velocity *= maxMoveSpeed;

        //
        //	at the end of the day,
        //
        this.transform.position += velocity; // DHDH = MAYBE THIS SHOULD BE A FUNCTION OF TIME.DELTATIME...

        Vector3 vPosFixup = this.transform.position;
        if (vPosFixup.y != groundHeight)
            vPosFixup.y = groundHeight;

        this.transform.position = vPosFixup;
    }

    private void UpdateSeek()
    {
        //
        //	seek, seeks to make a b-line woards to player
        //	// get the vector from where we are, to where we want to go...
        Vector3 vSteer = targetObj.transform.position - this.transform.position;
        vSteer.Normalize();
        vSteer = vSteer * maxSteerSpeed;

        // vSteer is the max change in velocity we can
        // apply to the character, to steer it in the right direction
        // towards the target

        // here, we are actually just using the steering vector as the speed
        velocity += vSteer; // this cant be right can it?
        velocity.Normalize();
        velocity *= maxMoveSpeed;

        //
        //	at the end of the day,
        //
        this.transform.position += velocity; // DHDH = MAYBE THIS SHOULD BE A FUNCTION OF TIME.DELTATIME...

        Vector3 vPosFixup = this.transform.position;
        if (vPosFixup.y < groundHeight)
            vPosFixup.y = groundHeight;

        this.transform.position = vPosFixup;
    }

    // Update is called once per frame
    void Update()
    {

        AILogicUpdate();

    }
}
