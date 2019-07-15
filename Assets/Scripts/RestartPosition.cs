using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPosition : MonoBehaviour {

	public GameObject restartPosition;
	// Use this for initialization
	void Start () {
		
	}
	public void Restart(GameObject obj)
	{
		if (obj != null)
		{
			obj.transform.position = restartPosition.transform.position;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
