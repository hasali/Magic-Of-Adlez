using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void AttachControl(GameObject obj)
	{
		if (obj != null)
		{
			Debug.Log ("hello");
			obj.transform.parent = this.transform;
		}
	}
	public void DetachControl(GameObject obj)
	{
		if (obj != null)
		{
			obj.transform.parent = null;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
