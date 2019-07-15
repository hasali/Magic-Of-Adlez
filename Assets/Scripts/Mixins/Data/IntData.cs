using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntData : Mixin
{
    // Use this for initialization
    void Start()
    {

    }

    // the actual value
    public int val;
    //public string description;

    public void Apply(IntData id)
    {
        val += id.val;
    }

    public void Deapply(IntData id)
    {
        val -= id.val;
    }

    public void Apply(FloatData data)
    {
        int value = Convert.ToInt32(Mathf.Floor(data.val));
        this.val += value;
    }

    public void UnApply(FloatData data)
    {
        int value = Convert.ToInt32(Mathf.Floor(data.val));
        this.val -= value;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}