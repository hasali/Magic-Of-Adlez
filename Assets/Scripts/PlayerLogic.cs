using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public float normalAtkTimer;
    float fireArrowTimer;
    float fireballAtkTimer;
    float iceAtkTimer;
    float iceDragonTimer;

    public GameObject targetEnemy;
    private IsTargeter targeter;

    Animator anim;
	public GameObject global;

    public float h;
    public float v;

    float walkSpeed;
    // float walkBckSpeed;
    float rotSpeed;

    public GameObject forwardTargetObj;

    SkillCollection pSCollection;

    Text HP;
    Text GP;
    Text AP;
    Text DP;

    // Use this for initialization
    void Start()
    {
        normalAtkTimer = 0.0f;
        fireArrowTimer = 0.0f;
        fireballAtkTimer = 0.0f;
        iceAtkTimer = 0.0f;
        iceDragonTimer = 0.0f;

        anim = this.gameObject.GetComponent<Animator>();
        walkSpeed = 2.5f;
        rotSpeed = 150.0f;
        // walkBckSpeed = 0.75f;

        HP = GameObject.Find("HP").GetComponent<Text>();
        GP = GameObject.Find("GP").GetComponent<Text>();
        AP = GameObject.Find("AP").GetComponent<Text>();
        DP = GameObject.Find("DP").GetComponent<Text>();

        pSCollection = this.GetComponent<SkillCollection>();
        targeter = GetComponent<IsTargeter>();
    }

    // read axis input from controller and make player walk fwd/back or turn l/r
    public void PlayerLogicUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        this.transform.Rotate(new Vector3(0.0f, h * rotSpeed * Time.deltaTime, 0.0f));
        if (v < 0)
        {
            this.transform.forward = -forwardTargetObj.transform.forward;
            //this.transform.Translate(new Vector3(0.0f, 0.0f, v * walkBckSpeed * Time.deltaTime));
            this.transform.position += this.transform.forward * -v * walkSpeed * Time.deltaTime;
        }
        else if (v > 0)
        {
            this.transform.forward = forwardTargetObj.transform.forward;
            //this.transform.Translate(new Vector3(0.0f, 0.0f, v * walkSpeed * Time.deltaTime));
            this.transform.position += this.transform.forward * v * walkSpeed * Time.deltaTime;
        }

        anim.SetFloat("Horizontal", h);
        anim.SetFloat("Vertical", v);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }

        //AnimatorStateInfo currAnimationState = anim.GetCurrentAnimatorStateInfo(0);

        if (pSCollection != null)
        {
//            if (targeter != null)
//            {
//                GameObject targetedObj = targeter.SelectTarget(5f);
//                foreach (IsASkill skill in pSCollection.skills)
//                {
//                    skill.target = targetedObj;
//                }
//            }
            //if (currAnimationState.IsName("Idle") ||
            //    currAnimationState.IsName("Run") ||
            //    currAnimationState.IsName("Run 0"))
            //{
            // normal attack
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                if (pSCollection.skills[0].isActive)
                {
                    pSCollection.skills[0].target = targeter.SelectTarget(pSCollection.skills[0].effectRange);
                    // disable the button
                    pSCollection.skills[0].isActive = false;
                    pSCollection.skills[0].activate();
                    anim.SetTrigger("Attack1");
                }
            }

            // fire medium attack
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                if (pSCollection.skills[1].isActive)
                {
					pSCollection.skills[1].target = targeter.SelectTarget(pSCollection.skills[1].effectRange);
					// disable the button
					pSCollection.skills[1].isActive = false;
					pSCollection.skills[1].activate();
                    anim.SetTrigger("Attack2");
                }
            }

            // fire strong attack
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                if (pSCollection.skills[2].isActive)
                {
					pSCollection.skills[2].target = targeter.SelectTarget(pSCollection.skills[2].effectRange);
					// disable the button
					pSCollection.skills[2].isActive = false;
					pSCollection.skills[2].activate();
                    anim.SetTrigger("Attack3");
                }
            }

            // ice medium attack
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                if (pSCollection.skills[3].isActive)
                {
					pSCollection.skills[3].target = targeter.SelectTarget(pSCollection.skills[3].effectRange);
					// disable the button
					pSCollection.skills[3].isActive = false;
					pSCollection.skills[3].activate();
                    anim.SetTrigger("Attack2");
                }
            }

            // ice strong attack
            if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                if (pSCollection.skills[4].isActive)
                {
					pSCollection.skills[4].target = targeter.SelectTarget(pSCollection.skills[4].effectRange);
					// disable the button
					pSCollection.skills[4].isActive = false;
					pSCollection.skills[4].activate();
                    anim.SetTrigger("Attack3");
                }
            }

            // do damage
            if (Input.GetKeyUp(KeyCode.Return))
            {
                this.GetComponent<IsDamager>().DoDamage(targetEnemy);
            }


            // ACTIVATE SKILLS AGAIN

            // normal attack animation has ended       
            //if (currAnimationState.IsName("Attack01"))
            //{
            //    // normal attack done playing; activate
            //    pSCollection.skills[0].isActive = true;
            //}
            if (!pSCollection.skills[0].isActive && normalAtkTimer < 1.0f)     // 1 second cooldown
            {
                Debug.Log(this.gameObject.name);
                normalAtkTimer += Time.deltaTime;
            }
            else
            {
                // reset timer back to 0 and activate skill again
                normalAtkTimer = 0.0f;
                pSCollection.skills[0].isActive = true;
            }

            // fire arrow timer has ended
            if (!pSCollection.skills[1].isActive && fireArrowTimer < 3.0f)     // 3 second cooldown
            {
                fireArrowTimer += Time.deltaTime;
            }
            else
            {
                // reset timer back to 0 and activate skill again
                fireArrowTimer = 0.0f;
                pSCollection.skills[1].isActive = true;
            }

            // fireball timer has ended
            if (!pSCollection.skills[2].isActive && fireballAtkTimer < 7.0f)     // 7 second cooldown
            {
                fireballAtkTimer += Time.deltaTime;
            }
            else
            {
                // reset timer back to 0 and activate skill again
                fireballAtkTimer = 0.0f;
                pSCollection.skills[2].isActive = true;
            }

            // ice attack timer has ended
            if (!pSCollection.skills[3].isActive && iceAtkTimer < 3.0f)     // 3 second cooldown
            {
                iceAtkTimer += Time.deltaTime;
            }
            else
            {
                // reset timer back to 0 and activate skill again
                iceAtkTimer = 0.0f;
                pSCollection.skills[3].isActive = true;
            }

            // ice dragon timer has ended
            if (!pSCollection.skills[4].isActive && iceDragonTimer < 7.0f)     // 7 second cooldown
            {
                iceDragonTimer += Time.deltaTime;
            }
            else
            {
                // reset timer back to 0 and activate skill again
                iceDragonTimer = 0.0f;
                pSCollection.skills[4].isActive = true;
            }
        }




        // check if HP is 0
        IntData[] attributes = GetComponents<IntData>();
        if (attributes != null)
        {
            //iterate through IntData attributes
            foreach (IntData attribute in attributes)
            {
                if (attribute.key == "HP")
                {
                    if (attribute.val <= 0)
                    {
                        // dead; call the Dead trigger
                        this.GetComponent<Animator>().SetTrigger("Dead");
                    }
                }
            }
        }
    }

    // dequip the appropriate equipment based on keypress
    public void InputUpdate()
    {
        IsAnEquipSlot[] iaeslots = this.gameObject.GetComponentsInChildren<IsAnEquipSlot>();
        foreach (IsAnEquipSlot iaes in iaeslots)
        {
            // left ctrl or mouse 0
            // dequips a shield
            if (Input.GetButton("Fire1"))
            {
                if (iaes.slotType == IsAnEquipSlot.eEquipSlotType.lhand)
                {
                    if (iaes.obj != null)
                    {
                        iaes.obj.GetComponent<IsEquipable>().dequip = true;
                    }
                }
            }

            // left alt or mouse 1
            // dequips a sword
            if (Input.GetButton("Fire2"))
            {
                if (iaes.slotType == IsAnEquipSlot.eEquipSlotType.rhand)
                {
                    if (iaes.obj != null)
                    {
                        iaes.obj.GetComponent<IsEquipable>().dequip = true;
                    }
                }
            }

            // left shift or mouse 2
            // dequips a helmet
            if (Input.GetButton("Fire3"))
            {
                if (iaes.slotType == IsAnEquipSlot.eEquipSlotType.head)
                {
                    if (iaes.obj != null)
                    {
                        iaes.obj.GetComponent<IsEquipable>().dequip = true;
                    }
                }
            }
        }
    }

    // update the UI with the appropriate stat values
    public void UIUpdate()
    {
        IntData[] ids = GetComponentsInChildren<IntData>();

        foreach (IntData id in ids)
        {
            /*if (id.key == "healthStat")
            {
                if (id.val < 0)
                {
                    HP.text = "0";      // don't show negative value in UI
                }
                else
                {
                    HP.text = id.val.ToString();
                }               
            }
            else*/
            if (id.key == "gold")
            {
                if (id.val < 0)
                {
                    GP.text = "0";      // don't show negative value in UI
                }
                else
                {
                    GP.text = id.val.ToString();
                }
            }
            else if (id.key == "attackStat")
            {
                AP.text = id.val.ToString();
            }
            else if (id.key == "defenseStat")
            {
                DP.text = id.val.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
		int currentHP = 1;
		IntData[] ids = this.gameObject.GetComponents<IntData> ();
		if (ids != null) {
			foreach (IntData id in ids) {
				if (id.key == "HP") {
					currentHP = id.val;
				}
			}
		}
		if (currentHP <= 0) {
			anim.SetTrigger ("Dead");
			global.GetComponent<GameMgr> ().ShowRestart ();
		} else {
			PlayerLogicUpdate ();
		}
        InputUpdate();
        UIUpdate();
    }
}