using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollectible : Mixin {

    public Texture2D thumbnail;

    public void Collect(GameObject go)
    {
        //
        //	put me in the 1st available slot in the collection I am supposed to go into
        //	(assume InventoryCollection on player)
        //

        // if the player has an inventory, try and put me in there
        InventoryCollection ic = go.GetComponent<InventoryCollection>();
        if (ic != null)
        {
            ic.Add(this);
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
