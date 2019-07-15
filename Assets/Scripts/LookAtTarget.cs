using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {
	Transform tf;
	public float rotationSpeed;
	public GameObject target;

	// Use this for initialization
	void Start () {
		tf = this.gameObject.transform;
		if (rotationSpeed == 0.0) {
			rotationSpeed = 1.0f;
		}
	}

	void LookAtTargetUpdate() {
		if (tf != null && target != null) {
			Quaternion neededRotation = Quaternion.LookRotation(target.transform.position - tf.position);
			tf.rotation = Quaternion.Slerp (tf.rotation, neededRotation, Time.deltaTime * rotationSpeed);
		}
	}

	// Update is called once per frame
	void Update () {
		LookAtTargetUpdate ();
	}
}
