using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {

	float y;
	public float length;
	public float speed;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = this.gameObject.transform;
		if (tf != null) {
			y = tf.position.y;
		}
		length = 1.0f;
		speed = 1.0f;
	}

	void UpDownUpdate() {
		if (tf != null) {
			tf.Translate(new Vector3(tf.position.x, y + (Mathf.Sin (Time.time * speed) * length), tf.position.z));
		}
	}

	// Update is called once per frame
	void Update () {
		UpDownUpdate ();
	}
}
