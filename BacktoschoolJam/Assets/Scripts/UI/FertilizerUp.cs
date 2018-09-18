using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FertilizerUp : MonoBehaviour {
    public TreesGrowth treeGrowth;
    public Transform imageLevel;
    public TextMeshProUGUI text;
    public MoneyManager money;
    public int level;
    public int cost;

    public void Update()
    {
        if (level < 4)
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
            if (level < 4)
            {
                ChangeLevelColor();
                level++;
                treeGrowth.GetComponent<TreesGrowth>().growSpeed -= 0.80f;
                money.moneyValue -= cost;
                 cost *= 6;
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
