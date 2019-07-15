using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLogic : MonoBehaviour {

    public GameObject targetEnemy;
	public float atkTimer;
	public eAttackMode curAMode;
	public float atkDelay;
	private IsTargeter targeter;
	SkillCollection dSCollection;
	public GameObject global;
	public int curHP;
	bool dead;

	Animator anim;

	public enum eAttackMode{
		INVALID = -1,
		NORMAL,
		FRENZY,
		COUNT
	}

    // Use this for initialization
    void Start () {
		atkTimer = 0.0f;
		atkDelay = -1.0f;
		curAMode = eAttackMode.NORMAL;
		anim = this.gameObject.GetComponent<Animator> ();
		targeter = this.gameObject.GetComponent<IsTargeter>();
		dSCollection = this.gameObject.GetComponent<SkillCollection> ();
		dead = false;
	}

	void AttackUpdate(){
		if (anim != null && atkTimer > atkDelay && !dead) {
			if (dSCollection != null) {
				switch (curAMode) {
				case eAttackMode.NORMAL:
					if ((int)atkTimer % 5 == 0) {
						if (dSCollection.skills [1].isActive) {
							dSCollection.skills [1].target = targeter.SelectTarget (dSCollection.skills [1].effectRange);
							// disable the button
							dSCollection.skills [1].isActive = false;
							dSCollection.skills [1].activate ();
						}
						anim.SetTrigger ("Attack");
					} else if ((int)atkTimer % 2 == 0) {
						if (dSCollection.skills [0].isActive) {
							dSCollection.skills [0].target = targeter.SelectTarget (dSCollection.skills [0].effectRange);
							// disable the button
							dSCollection.skills [0].isActive = false;
							dSCollection.skills [0].activate ();
						}
						anim.SetTrigger ("Attack");
					}
					break;
				case eAttackMode.FRENZY:
					if ((int)atkTimer % 3 == 0) {
						if (dSCollection.skills [1].isActive) {
							dSCollection.skills [1].target = targeter.SelectTarget (dSCollection.skills [1].effectRange);
							// disable the button
							dSCollection.skills [1].isActive = false;
							dSCollection.skills [1].activate ();
						}
						anim.SetTrigger ("Attack");

					} else if ((int)atkTimer % 1 == 0) {
						if (dSCollection.skills [0].isActive) {
							dSCollection.skills [0].target = targeter.SelectTarget (dSCollection.skills [0].effectRange);
							// disable the button
							dSCollection.skills [0].isActive = false;
							dSCollection.skills [0].activate ();
						}
						anim.SetTrigger ("Attack");
					}
					break;
				}
			}
			atkDelay = atkTimer + 1;
		}
		atkTimer += Time.deltaTime;
		foreach (IsASkill skill in dSCollection.skills) {
			skill.isActive = true;
		}
	}

    void DragonLogicUpdate()
    {
        // do damage
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            this.GetComponent<IsDamager>().DoDamage(targetEnemy);
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
					if (attribute.val <= 0) {
						// dead; call the Dead trigger
						this.GetComponent<Animator> ().SetTrigger ("Dead");
						global.GetComponent<GameMgr> ().ShowWin ();
					} else if (attribute.val < 50) {
						curAMode = eAttackMode.FRENZY;
					}
					curHP = attribute.val;
					if (curHP <= 0) {
						dead = true;
					}
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        DragonLogicUpdate();
		AttackUpdate ();
	}
}
