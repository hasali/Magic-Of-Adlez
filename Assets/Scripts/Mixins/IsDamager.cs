using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsDamager : MonoBehaviour {

    public List<DamageMessage> damageTable;

	// Use this for initialization
	void Start () {
        DamageMessage[] dms = GetComponents<DamageMessage>();
        for(int i=0;i<dms.Length;i++)
        {
            if (dms[i].outGoing)
            {
                damageTable.Add(dms[i]);
            }
        }
	}

    public void DoDamage(GameObject target)
    {
        Debug.Log("Dealing damage to "+target.name);
        target.SendMessage("TakeDamage", damageTable);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
