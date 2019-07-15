using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public const float maxHealth = 100.0f;
    public float currentHealth = maxHealth;
    public RectTransform healthBar;
	float originalWidth;

    // already a TakeDamage method in IsDamageable
	// so update current health using IntData instead
//    public void TakeDmg(float amount)
//    {
//        currentHealth -= amount;
//        if (currentHealth <= 0.0f)
//        {
//            currentHealth = 0.0f;
//            Debug.Log("Dead!");
//        }
//
//        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
//    }

    // Use this for initialization
    void Start () {
		if (healthBar != null) {
			originalWidth = healthBar.rect.width;
		}
	}

	void HealthUpdate() {
		IntData[] ids = this.gameObject.GetComponents<IntData> ();
		if (ids != null) {
			foreach (IntData id in ids) {
				if (id.key == "HP") {
					id.val = (int)Mathf.Clamp (id.val, 0, maxHealth);
					currentHealth = id.val;
				}
			}
		}
		if (currentHealth <= 0.0f)
		{
			currentHealth = 0.0f;
			Debug.Log("Dead!");
		}
		float scale = currentHealth / maxHealth;
		healthBar.sizeDelta = new Vector2(scale * originalWidth, healthBar.sizeDelta.y);
	}
	
	// Update is called once per frame
	void Update () {
		HealthUpdate ();
	}
}
