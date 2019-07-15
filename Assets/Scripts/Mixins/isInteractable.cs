using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//If an object is interactible, it means some other entity can interact with it by some means other than triggers or colliders
//also, if it is the player interacting with it, this class will generate a message to display on the HUD
public class isInteractable : MonoBehaviour {

    public KeyCode interactionKey;
    public UnityEvent onInteractionCB;
    //The type of entity that can interact with the interactable object
    //Note tht this isn't actually implemented anywhere yet
    public enum InteractionEntityType
    {
        player,
        enemy,
        all,
        none
    }
    public InteractionEntityType entityType;
    //I couldn't think of a good name for this variable
    //It is the thing that happens when you press the interaction key
    public string interactionMessageString;
    
    private bool interactionEnabled = false;

    public void SetInteractionEnabled(bool enabledState)
    {
        interactionEnabled = enabledState;
        //if interaction is enabled, and it is  player interaction,
        if (isInteractionEnabled() && entityType == InteractionEntityType.player)
        {
            //display an HUD message telling the player what they can do
            UIManager.UpdateUI_Interaction(GetInteractionMessage());
        }
        else
        {
            //otherwise, hide the message
            UIManager.UpdateUI_Interaction("");
        }
    }
    
    private string GetInteractionMessage()
    {
        string message = "";
        //if there's a key that can be pressed,
        if (interactionKey.ToString() != "None")
        {
            //tell the user which key
            message += "Press [" + interactionKey.ToString() + "]";
            //if the designer specified what happens when you press the button,
            if (interactionMessageString.Trim() != "")
            {
                //add it to the message
                message += " to " + interactionMessageString;
            }
        }
        else
        {
            //For cases where an object is "interactable", but you can't actually invoke functions with it
            //for example, if a door is locked, you want to show a message but not be able to do anything
            message = interactionMessageString;
        }

        return message;
    }

    public bool isInteractionEnabled()
    {
        return interactionEnabled;
    }

    public void InteractionUpdate()
    {
        if (isInteractionEnabled())
        {
            if (Input.GetKeyDown(interactionKey))
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        if(onInteractionCB != null)
        {
            onInteractionCB.Invoke();
        }
    }

    public void SetInteractionMessageString(string newMessage)
    {
        interactionMessageString = newMessage;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InteractionUpdate();
	}
}
