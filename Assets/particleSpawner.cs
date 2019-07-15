using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSpawner : MonoBehaviour {
	public GameObject spawnThis;
	// Use this for initialization
	void Start () {
		
	}

	void particleSpawnerUpdate(){
		if (Input.GetKeyUp(KeyCode.Q)){
			if(spawnThis != null)
			Instantiate(spawnThis);
		}
	}

	// Update is called once per frame
	void Update () {
		particleSpawnerUpdate ();
	}
}
