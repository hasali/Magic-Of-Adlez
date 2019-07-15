using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static Text labelHP;
    private static Text labelGold;
    private static Text labelMagicka;
    private static Text labelInteraction;

    // Use this for initialization
    void Start () {
        Text[] allTexts = GameObject.FindObjectsOfType<Text>();

        foreach(Text text in allTexts)
        {
            if(text.name == "valHP")
            {
                labelHP = text;
                continue;
            }
            if (text.name == "valGld")
            {
                labelGold = text;
                continue;
            }
            if (text.name == "valMgk")
            {
                labelMagicka = text;
                continue;
            }
            if (text.name == "lblInteraction")
            {
                labelInteraction = text;
                continue;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void UpdateUI_HP(int hp)
    {
        labelHP.text = hp.ToString();
    }

    public static void UpdateUI_Gold(int gold)
    {
        labelGold.text = gold.ToString();
    }

    public static void UpdateUI_Magicka(int magicka)
    {
        labelMagicka.text = magicka.ToString();
    }

    public static void UpdateUI_Interaction(string message)
    {
        //The <b> tags work as long as the text element has the "rich text" checkbox checked
        labelInteraction.text = "<b>"+message+"</b>";
    }
}
