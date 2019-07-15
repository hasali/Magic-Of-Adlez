using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A damagemessage describes the type of damage taken OR given by a damager or damagable character
//note that if there is no damagemessage for a damagetype attached to a character, the chracter takes full damage (ie damageAmount = 1)
public class DamageMessage : MonoBehaviour {

    //Type of damage
    public DamageType.eDamageType type;
    //Character attribute to damage
    //This exists so we can specify that an attack deals damage to attributes other than HP (eg Magicka draining attacks, stamina, etc)
    //Mapped to IntData with a matching description
    public string damageAttribute;
    //OUTGOING - negative values do damage, positive values heal
    //INCOMING - values < 1 give resistance, values > 1 give vulnerability
    public float damageAmount;
    //if outgoing is true, then this damageMessage is for ATTACKS DEALT
    //if outgoing is false, then this damageMessage if for ATTACKS RECIEVED
    public bool outGoing;

    public FloatData magnitude;

	// Use this for initialization
	void Start () {
        magnitude = gameObject.AddComponent<FloatData>();
        magnitude.description = damageAttribute;
        magnitude.val = damageAmount;
	}
}
