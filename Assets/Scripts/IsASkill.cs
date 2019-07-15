using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsASkill : MonoBehaviour {

    public Texture activeImg;
    public Texture inactiveImg;
	public GameObject skillEffect;
	public GameObject target;
    public float effectRange;
	IsDamager dmgSrc;

    public bool isActive;

	// Use this for initialization
	void Start () {
		dmgSrc = this.gameObject.GetComponent<IsDamager> ();
        if (effectRange == 0)
        {
            effectRange = Mathf.Infinity;
        }
	}

	public void activate() {
		if( skillEffect != null && target != null){
			Instantiate(skillEffect, target.transform);
			if (dmgSrc != null) {
				Debug.Log ("this is a damager");
				dmgSrc.DoDamage (target);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
