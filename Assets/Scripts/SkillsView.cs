using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsView : MonoBehaviour {

    public Animator chara;
    public Texture[] textures;
    //float normalAtkTimer;
    public GameObject skill1;
    public SkillCollection sCollection;
    Component[] skillImgs;
    //int index;

    // Use this for initialization
    void Start () {
        //normalAtkTimer = 0.0f;
        //index = 0;
        //sCollection = GetComponent<SkillCollection>();
	}

    void SkillsViewUpdate()
    {
        // gets all rawimage components in skillview
        skillImgs = GetComponentsInChildren<RawImage>();

        if (sCollection != null)
        {
            int index = 0;

            //loop through sCollection to get the IsaSkill images
            foreach (RawImage skillImg in skillImgs)
            {
                //replace the appropriate image for the status of the skill
                if (sCollection.skills[index].isActive)
                {
                    skillImg.texture = sCollection.skills[index].activeImg;
                }
                else
                {
                    skillImg.texture = sCollection.skills[index].inactiveImg;
                }
            index++;
            }
        }

        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //{
        //    this.GetComponentInChildren<RawImage>().texture = textures[1];   // normal atk presssed texture            
        //}

        //// animation has ended
        //if (chara.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        //{
        //    this.GetComponentInChildren<RawImage>().texture = textures[0];   // normal atk tex
        //}
        //if (normalAtkTimer < 1.0f)
        //{
        //    normalAtkTimer += Time.deltaTime;
        //}
        //else
        //{
        //    normalAtkTimer = 0.0f;

        //}
    }

	// Update is called once per frame
	void Update () {
        SkillsViewUpdate();
	}
}
