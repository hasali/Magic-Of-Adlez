using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData : MonoBehaviour {

    public string description;
    public float val;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public FloatData(string description, float val)
    {
        this.description = description;
        this.val = val;
    }

    public FloatData()
    {
    }

    public void Apply(IntData data)
    {
        this.val += data.val;
    }

    public void UnApply(IntData data)
    {
        this.val -= data.val;
    }

    public void Apply(FloatData data)
    {
        this.val += data.val;
    }

    public void UnApply(FloatData data)
    {
        this.val -= data.val;
    }
}
