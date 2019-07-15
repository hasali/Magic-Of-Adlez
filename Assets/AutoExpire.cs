using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoExpire : MonoBehaviour {
	private ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}

	void AutoExpireUpdate(){
		if (ps != null) {
			if (!ps.IsAlive ()) {
				Destroy (this.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		AutoExpireUpdate ();
	}
}
