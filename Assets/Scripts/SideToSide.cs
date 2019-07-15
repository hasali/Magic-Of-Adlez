using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour {
	
	float z;
	public float length;
	public float speed;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = this.gameObject.transform;
		if (tf != null) {
			z = tf.position.z;
		}

	}

	void SideToSideUpdate() {
		if (tf != null) {
			tf.position = (new Vector3(tf.position.x, tf.position.y, z + (Mathf.Sin (Time.time * speed) * length)));
		}
	}
	
	// Update is called once per frame
	void Update () {
		SideToSideUpdate ();
	}
}
