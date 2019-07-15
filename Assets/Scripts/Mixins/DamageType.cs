using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageType : MonoBehaviour {

    public enum eDamageType
    {
        invalid = -1,
        bludgeon = 0,
        slash = 1,
        pierce = 2,
        fire = 3,
        water = 4,
        frost = 5,
        shock = 6,
        air = 7
    }
}
