using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsConsumable : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    public void Consume(GameObject obj)
    {
        // check for any consumables
        // check for any attributes that match by name to the player
        // if they match, apply the delta
        IntData[] ids = GetComponentsInChildren<IntData>();
        IntData[] idsObj = obj.GetComponentsInChildren<IntData>();

        foreach (IntData id in ids)
        {
            foreach (IntData idObj in idsObj)
            {
                if (idObj.key == id.key /*+ "Stat"*/)
                {
                    // they match; apply it
                    idObj.Apply(id);
                    break;
                }
            }
        }
        Destroy(this.gameObject);       
    }

    // Update is called once per frame
    void Update()
    {

    }
}