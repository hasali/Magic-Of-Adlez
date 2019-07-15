using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAnEquipSlot : MonoBehaviour
{
    public enum eEquipSlotType
    {
        invalid = -1,
        lhand,
        rhand,
        head
    };

    public eEquipSlotType slotType;
    public GameObject obj;			    // ref to obj slotted here
}
