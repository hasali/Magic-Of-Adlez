using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargeter : MonoBehaviour {

    public GameObject SelectTarget()
    {
        return SelectTarget(Mathf.Infinity);
    }

    public GameObject SelectTarget(float range)
    {
		Component[] targetedObjs = GameObject.FindObjectsOfType<IsTargetable>();
		if (this.gameObject.name != "Chara_4Hero") {
			targetedObjs = GameObject.FindObjectsOfType<IsAPlayer> ();
		}
        GameObject targetedObj = GetClosestTarget(targetedObjs, range);

        if (targetedObj != null)
            return targetedObj.gameObject;
        else
            return null;
    }

    private GameObject GetClosestTarget(Component[] targets, float range)
    {
        GameObject closest = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
		foreach (var t in targets)
        {
            float dist = Vector3.Distance(t.gameObject.transform.position, currentPosition);
            if (dist < shortestDistance && dist <= range)
            {
                closest = t.gameObject;
                shortestDistance = dist;
            }
        }
        return closest;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
