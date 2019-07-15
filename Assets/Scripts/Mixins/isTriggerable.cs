using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class isTriggerable : MonoBehaviour
{

    public string TriggerType;
    public UnityEvent OnTriggerEnterCB;
    public UnityEvent OnTriggerExitCB;
    public UnityEvent OnTriggerStayCB;
    //method that will be called via SendMessage()
    public string OnTriggerStayCBString;
    //how often, in seconds, to call the triggerStay callback
    //note that anything less than 1 second tends to cause frame drops
    public float OnTriggerStayInterval;
    //how much time has passed since the last time triggerStayCB was called
    private float onTriggerStayIntervalElapsed;

    //public string OnTouchCB;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(TriggerType) != null)
        {
            if (OnTriggerEnterCB != null)
            {
                OnTriggerEnterCB.Invoke();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent(TriggerType) != null)
        {
            if (OnTriggerExitCB != null)
            {
                OnTriggerExitCB.Invoke();
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent(TriggerType) != null)
        {
            if(OnTriggerStayInterval > 0f)
            {
                onTriggerStayIntervalElapsed += Time.deltaTime;
                if(onTriggerStayIntervalElapsed >= OnTriggerStayInterval)
                {
                    if (OnTriggerStayCB != null)
                    {
                        OnTriggerStayCB.Invoke();
                    }
                    if (OnTriggerStayCBString.Trim() != "")
                    {
                        SendMessage(OnTriggerStayCBString, other.gameObject);
                    }
                    onTriggerStayIntervalElapsed = 0f;
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
