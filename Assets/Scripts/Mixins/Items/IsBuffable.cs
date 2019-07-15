using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsBuffable : MonoBehaviour
{
    public void Buff(GameObject obj)
    {
        // check for any buffs
        // check for any attributes that match by name to the player
        // if they match, apply the delta
        IntData[] ids = GetComponentsInChildren<IntData>();
        IntData[] idsObj = obj.GetComponentsInChildren<IntData>();

        foreach (IntData id in ids)
        {
            foreach (IntData idObj in idsObj)
            {
                if (idObj.key == id.key)
                {
                    // they match; apply it
                    id.Apply(idObj);

                    // don't go negative
                    if ((id.key == "attack" || id.key == "defense") && id.val < 0)
                    {
                        id.val = 0;
                    }
                }
            }
        }
    }

    // remove all buffs
    public void Neutralize()
    {
        IntData[] ids = GetComponentsInChildren<IntData>();

        foreach (IntData id in ids)
        {
            if (id.key == "attack")
            {
                foreach (IntData id2 in ids)
                {
                    if (id2.key == "initAttack")
                    {
                        id.val = id2.val;
                    }
                }
            }

            if (id.key == "defense")
            {
                foreach (IntData id2 in ids)
                {
                    if (id2.key == "initDefense")
                    {
                        id.val = id2.val;
                    }
                }
            }

            if (id.key == "gold" || id.key == "health")
            {
                id.val = 0;
            }
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