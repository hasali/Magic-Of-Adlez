using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDamageable : MonoBehaviour {

    public List<DamageMessage> damageTable;
    //Health health;

    private void Start()
    {
        //health = GetComponent<Health>();
    }

    public List<FloatData> TakeDamage(List<DamageMessage> attackTable)
    {
        damageTable = BuildDamageTable();
        Debug.Log("Inside "+gameObject.name+", taking damage");
        List<FloatData> retVal = new List<FloatData>();
        //iterate through each incoming attack
        foreach(DamageMessage attack in attackTable)
        {
            Debug.Log(attack.damageAttribute);
            bool entryExists = false;
            //iterate through damagetable
            foreach(DamageMessage tableEntry in damageTable)
            {
                //if matching damage type,
                if(tableEntry.type == attack.type)
                {
                    entryExists = true;
                    applyAttackDamage(attack.magnitude, tableEntry.magnitude);
                }
            }
            //if there is no damage table entry for the specified damage type, 
            if (!entryExists)
            {
                //assume the damageable entity has no resistance or vulnerability
                applyAttackDamage(attack.magnitude, new FloatData(attack.magnitude.description, 1f));
            }
        }
        return retVal;
    }

    //gets attributes from damagebale entity and applys damage if attribute exists
    private FloatData applyAttackDamage(FloatData attack, FloatData defence)
    {
        FloatData retVal = new FloatData();

        //get FloatData attributes of damageable entity
        IntData[] attributes = GetComponents<IntData>();
        if (attributes != null)
        {
            //iterate through FloatData attributes on damageable object
            foreach (IntData attribute in attributes)
            {
                //if there is a match, apply damage
                //This implementation allows a damagemessage to deal damage to ANY FloatData attribute on the object, not just HP
                //for example, this makes it easy to make attacks that drain magicka, gold, etc
                //if (attribute.description == attack.description)
                if (attribute.key == attack.description)
                {
                    FloatData calculatedDamage = new FloatData();
                    calculatedDamage.val = attack.val * defence.val;
                    calculatedDamage.description = attack.description;
                    attribute.Apply(calculatedDamage);  

					//unnecessary call to reduce health since there is already IntData for health
                    //health.TakeDmg(Mathf.Abs(calculatedDamage.val));

                    retVal = calculatedDamage;
                }
            }
        }
        else
        {
            Debug.Log("The DamageAble object " + gameObject.name + "doesn't have any attributes to apply damage to!");
        }
        return retVal;
    }
    
    private List<DamageMessage> BuildDamageTable()
    {
        DamageMessage[] dms = GetComponents<DamageMessage>();
        List<DamageMessage> newTable = new List<DamageMessage>();
        for (int i = 0; i < dms.Length; i++)
        {
            if (!dms[i].outGoing)
            {
                newTable.Add(dms[i]);
            }
        }
        return newTable;
    }
}
