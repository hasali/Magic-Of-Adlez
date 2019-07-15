using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
//	check for how many slots are in my 'view'
//  display thumbnails for all the 'IsCollectible' items in the 'collection' I am intersted in showing
//
public class InventoryView : MonoBehaviour {

    public List<IsAnInventorySlot> slots;
    public InventoryCollection collection;
	public Texture empty;

    // Use this for initialization
    void Start()
    {
        // find out how many slots I have
        IsAnInventorySlot[] islots = GetComponentsInChildren<IsAnInventorySlot>();

        if (islots != null)
        {
            //
            //	how do we add islots to slots
            //
            slots.AddRange(islots);
        }
    }

    public void InventoryViewUpdate()
    {
        // show thumbs for items in my collection...
        if (collection != null)
        {
            //
            int index = 0;
            foreach (IsAnInventorySlot iis in slots)
            {
                //
                RawImage ri = iis.gameObject.GetComponent<RawImage>();
                if (ri != null)
                {
                    //
                    if (collection != null)
                    {
                        IsCollectible ic = collection.GetItem(index);
                        if (ic != null)
                        {
                            ri.texture = ic.thumbnail;// the texture from the IsCollectible
                        }                           
                        else
                        {
							ri.texture = empty;
                        }
                    }
                }
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        InventoryViewUpdate();
    }
}
