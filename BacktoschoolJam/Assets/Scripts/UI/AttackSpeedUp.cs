using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AttackSpeedUp : MonoBehaviour {
    public Player player;
    public Transform imageLevel;
    public TextMeshProUGUI text;
    public Money money;
    public int level;
    public int cost;

    public void Update()
    {
        if (level < 4)
        {
            text.text = "Cost: " + cost;
        }
        else
        {
            text.text = "Level Maxed";
        }
    }

    public void levelUp()
    {
        if (money.moneyValue >= cost)
        {
            if (level < 4)
            {
                ChangeLevelColor();
                level++;
                player.GetComponent<Player>().delaytime -= 0.25f;
                money.moneyValue -= cost;
                cost *= 4;
            }
            
        }
    }

    public void ChangeLevelColor()
    {
        if (level < 4)
        {
            imageLevel.GetComponent<Transform>().GetChild(level).GetComponent<Image>().color = new Color(1f, 0, 0, .7f);
        }

    }


}
