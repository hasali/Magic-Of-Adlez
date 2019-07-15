using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsUsable : Mixin {

    public string OnUseCB;
    //public string UseType;

    public void Use(GameObject obj)
    {
        SendMessage(OnUseCB, obj);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
