using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollection : MonoBehaviour {

    public List<IsASkill> skills;

    //public Animator chara;

    // Use this for initialization
    void Start () {
		//skills = new List<IsASkill>();

        // all non pressed skills are set to active
        for(int i = 0; i < skills.Count; i++)
        {
            skills[i].isActive = true;
        }
    }
	
    void SkillsCollectionUpdate()
    {
    }

    // Update is called once per frame
    void Update () {
        SkillsCollectionUpdate();
    }
}
