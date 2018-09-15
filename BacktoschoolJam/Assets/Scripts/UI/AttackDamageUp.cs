using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AttackDamageUp : MonoBehaviour {
    public TreesGrowth treesGrowth;
    public Transform imageLevel;
    public TextMeshProUGUI text;
    public MoneyManager money;
    public int level;
    public int cost;

    public void Update()
    {
        if (level < 7)
        {
            text.text = "Cost: $" + cost;
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
            if (level < 7)
            {
                ChangeLevelColor();
                level++;
                treesGrowth.GetComponent<TreesGrowth>().damage++;
                money.moneyValue -= cost;
                cost *= 2;
            }
        }
    }

    public void ChangeLevelColor()
    {
        if (level < 7)
        {
            imageLevel.GetComponent<Transform>().GetChild(level).GetComponent<Image>().color = new Color(1f, 0, 0, .7f);
        }

    }
}
