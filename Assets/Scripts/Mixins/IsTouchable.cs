using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchable : MonoBehaviour
{
    public string TouchType;
    public string OnTouchCB;

    // Use this for initialization
    void Start()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        // if something touched me that I am supposed to respond to, respond to it
        // how do I know if I should respond?
        if (other.gameObject.GetComponent(TouchType) != null)
        {
            // respond...
            if (OnTouchCB != "")
            {
                SendMessage(OnTouchCB, other.gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}