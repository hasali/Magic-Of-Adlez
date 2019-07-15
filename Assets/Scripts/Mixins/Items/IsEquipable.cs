using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsEquipable : Mixin
{
    public IsAnEquipSlot.eEquipSlotType slotType;
                                                    
    public bool dequip;

    public GameObject inventoryViewObj;

    InventoryCollection inventoryList;

    IsAnInventorySlot[] islots;

    IsCollectible icEquip;

    IsUsable use;
    // Use this for initialization
    void Start()
    {
        islots = inventoryViewObj.GetComponentsInChildren<IsAnInventorySlot>();
        icEquip = GetComponent<IsCollectible>();
    }


    // equip an equipable item that the player touched
    public void Equip(GameObject obj)
    {
        //	put into the first available equip slot that makes sense
        IsAnEquipSlot[] iaeslots = obj.GetComponentsInChildren<IsAnEquipSlot>();

        foreach (IsAnEquipSlot iaes in iaeslots)
        {
            if (iaes.slotType == slotType)
            {
                // dequip the current item if another equipable item is to replace it
                if(iaes.obj != null)
                {
                    iaes.obj.GetComponent<IsEquipable>().Dequip();
                }

                // put the item in this slot
                iaes.obj = this.gameObject;

                // set the item's rotation to look "right" on the player
                if (iaes.obj == GameObject.Find("SkullShieldEquipSlot"))
                {
                    iaes.gameObject.transform.localRotation = Quaternion.Euler(-19.0f, -38.0f, -84.0f);
                }
                else if (iaes.obj == GameObject.Find("ElvenShieldEquipSlot"))
                {
                    iaes.gameObject.transform.localRotation = Quaternion.Euler(1.0f, -35.0f, 6.0f);
                }
                else if (iaes.obj == GameObject.Find("CelestialConquerer"))
                {
                    iaes.gameObject.transform.localRotation = Quaternion.Euler(-29.0f, 53.0f, 240.0f);
                }
                else if (iaes.obj == GameObject.Find("HellBreaker"))
                {
                    iaes.gameObject.transform.localRotation = Quaternion.Euler(141.0f, 55.0f, 291.0f);
                }
                else if (iaes.obj == GameObject.Find("ArmourHelmet"))
                {
                    iaes.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 5.4f);
                }
                
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = this.gameObject.AddComponent<Rigidbody>();
                }
                rb.isKinematic = true;

                // make sure it has a collider that is a trigger
                Collider col = this.gameObject.GetComponent<Collider>();
                if (col != null)
                    col.isTrigger = true;

                // make sure we don't touch the item again
                this.transform.parent = iaes.transform;

                // fix the rotation
                this.gameObject.transform.rotation = iaes.transform.rotation;
                this.gameObject.transform.position = iaes.transform.position;

                // check for any equipment attributes
                // check for any attributes that match by name to the player
                // if they match, apply the delta
                IntData[] ids = GetComponentsInChildren<IntData>();
                IntData[] idsObj = obj.GetComponentsInChildren<IntData>();

                foreach (IntData id in ids)
                {
                    foreach (IntData idObj in idsObj)
                    {
                        if (idObj.key == id.key + "Stat")
                        {                    
                            // they match; apply it
                            idObj.Apply(id);
                        }
                    }
                }
                break;               
            }
        }
    }

    // dequip an item
    public void Dequip()
    {
        //
        //	detach from the hierarchy
        //  find the slot we are equipped in and clear it
        //  put our item back in the world under physics control
        //

        GameObject slotObj = this.gameObject.transform.parent.gameObject;
        IsAnEquipSlot iaes = slotObj.GetComponent<IsAnEquipSlot>();
        inventoryList = slotObj.GetComponentInParent<InventoryCollection>();

        if (iaes != null)
        {
            IntData[] ids = GetComponentsInChildren<IntData>();
            IntData[] idsObj = slotObj.GetComponentsInParent<IntData>();

            foreach (IntData id in ids)
            {
                foreach (IntData idObj in idsObj)
                {
                    if (idObj.key == id.key + "Stat")
                    {
                        idObj.Deapply(id);                       
                    }
                }
            }

            // set EquipLoc rotation back to default
            // makes items dequip properly onto shrine
            iaes.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            //
            //	1) empty the slot
            //

            iaes.obj = null;

            // cache player root obj reference for step 3) below so we know what is in front 
            GameObject playerRootObj = iaes.transform.root.gameObject;          

            //
            //	2) drop it..
            // needs to be the inverse of whatever we end up doing in 'equip' to make sure the orientation works right
            this.gameObject.transform.parent = null;

            if (inventoryList.objs.Count < islots.Length)
            {
                icEquip.Collect(slotObj.transform.root.gameObject);
            }
            else
            {
                // drop it a few units in front of the player under physics control
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = this.gameObject.AddComponent<Rigidbody>();
                }
                rb.isKinematic = false;

                // make sure it has a collider thats not a trigger
                Collider col = this.gameObject.GetComponent<Collider>();
                if (col != null)
                    col.isTrigger = false;

                //
                //	3) in front of us far enough so that we don't try and pick it up again
                //
                float farEnough = 2.5f;
                Vector3 pointInFrontOfPlayer = playerRootObj.transform.position + (farEnough * playerRootObj.transform.forward);

                this.gameObject.transform.position = pointInFrontOfPlayer + new Vector3(0.0f, 1.5f, 0.0f);
            }

             
        }
    }

    public void IsEquipableUpdate()
    {
        if (dequip == true)
        {
            Dequip();
            dequip = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsEquipableUpdate();
    }
}
