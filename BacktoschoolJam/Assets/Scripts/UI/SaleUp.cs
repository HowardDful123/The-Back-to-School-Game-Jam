using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaleUp : MonoBehaviour {
    public Transform imageLevel;
    public TextMeshProUGUI text;
    public MoneyManager money;
    public WoodCarrier woodCarrier;
    public int level;
    public int cost;


	void Update () {
        if (level < 5)
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
            if (level < 5)
            {
                ChangeLevelColor();
                level++;
                money.moneyValue -= cost;
                woodCarrier.saleMoney++;
                cost *= 3;
            }
        }
    }

    public void ChangeLevelColor()
    {
        if (level < 5)
        {
            imageLevel.GetComponent<Transform>().GetChild(level).GetComponent<Image>().color = new Color(1f, 0, 0, .7f);
        }

    }
}
