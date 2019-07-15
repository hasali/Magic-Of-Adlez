using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public bool canFade;
	MeshRenderer[] meshRenderers;
	float timeToFade = 1.0f;
	float timeToDelete = 3.0f;
	Color alpha;
	public enum eFadeControl
	{
		invalid = -1,
		fadeOut = 0,
		fadeIn = 1,
		fadeAndDestroy = 2
	};

	public eFadeControl fadeType;


	// Use this for initialization
	void Start () 
	{
		meshRenderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();

	}
	public void SetFade(int newBehaviour)
	{
		fadeType = (eFadeControl)newBehaviour;
	}
	public void FadeControl()
	{
		if (fadeType == 0)
		{
			FadeOut ();
		}
		else if ((int)fadeType == 1)
		{
			FadeIn ();
		}
		else if ((int)fadeType == 2)
		{
			FadeAndDestroy ();
		}
	}
		
	public void FadeOut()
	{
		Debug.Log ("Interact: FadeOut");

		//slowly fade from solid to completely transparent
		foreach (MeshRenderer mesh in meshRenderers)
		{
			Color alpha = mesh.material.color;
			alpha.a = 0;
			mesh.material.color = Color.Lerp (
				mesh.material.color, alpha, Time.deltaTime * timeToFade);
		}

	}
	public void FadeIn()
	{
		//From trasparent go to solid
		Debug.Log ("Interact: FadeIn");
		foreach (MeshRenderer mesh in meshRenderers)
		{
			Color alpha = mesh.material.color;
			alpha.a = 1;
			mesh.material.color = Color.Lerp (
				alpha, mesh.material.color, Time.deltaTime * timeToFade);	
		}
		
	}
	public void FadeAndDestroy()
	{
		
		timeToDelete -= Time.deltaTime;
		FadeOut ();

		if (timeToDelete <= 0)
			Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		FadeControl ();

	}
}
