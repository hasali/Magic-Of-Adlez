using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollection : MonoBehaviour {

    public List<IsCollectible> objs;

    public GameObject inventoryViewObj;

    IsAnInventorySlot[] islots;

    //
    //	interact with object in inventory
    //	-we want to use the primary use of the object
    //  -so get the object at this index, and use it
    public void UseItemAtIndex(int index)
    {

        // if it's usable
        // first get the object at index
        // then if it's usable, use it
        if (index < objs.Count)
        {
            IsCollectible ic = objs[index];
            if (ic != null)
            {
                //
                GameObject invObj = ic.gameObject;
                IsUsable hasUse = invObj.GetComponent<IsUsable>();
                if (hasUse != null)
                {
                    //
                    //invObj.SetActive(true);
                    Remove(ic);
                    hasUse.Use(this.gameObject);//invObj); //dhdh - todo: make sure we pass the right collection owner here
                                                //invObj.SetActive(false);
                }
            }
        }
    }

    public IsCollectible GetItem(int index)
    {
        IsCollectible rval = null;

        if (index < objs.Count)
            rval = objs[index]; // assuming this is not out of range...

        return rval;
    }

    public void Add(IsCollectible obj)
    {
        if (objs != null)
        {
            if (objs.Count < islots.Length)
            {
                // add the item
                objs.Add(obj);

                // do some fixup
                obj.gameObject.SetActive(false); // maybe revisit this.

                // show the thumb (maybe)  
            }
        }
    }

    public void Remove(IsCollectible obj)
    {
        if(objs != null)
        {
            objs.Remove(obj);
            obj.gameObject.SetActive(true);
        }
    }

    // Use this for initialization
    void Start()
    {
        // maybe we should serialie and load this after midterm... dhdh
        objs = new List<IsCollectible>();

        islots = inventoryViewObj.GetComponentsInChildren<IsAnInventorySlot>();
        // find out how many slots I have
        //islots = inventoryViewObj.GetComponentsInChildren<IsAnInventorySlot>();

        //if (islots != null)
        //{
        //    //
        //    //	how do we add islots to slots
        //    //
        //   // numAvailableSlots = islots.Length;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
