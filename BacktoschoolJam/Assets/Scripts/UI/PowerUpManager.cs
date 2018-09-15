using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {
    public GameObject powerUpUIPanel;
    public Text capacityText;
    public Text capacityCost;
    public Text decreaseTaxText;
    public Text decreaseTaxCost;
    public WoodCarrier woodCarrier;
    public MoneyManager money;
    public int cost;
    public int taxCost;

    void Update()
    {
        capacityText.text = "Capacity: " + woodCarrier.plankNumber + "/" + woodCarrier.plankCapacity;    
        capacityCost.text = "Cost: $" + cost;
        decreaseTaxText.text = "Tax: $" + money.taxAmount;
        decreaseTaxCost.text = "Cost: $" + taxCost;

    }

    public void DecreaseTax()
    {
         if (money.moneyValue >= taxCost)
         {
             money.taxAmount -= 5;
             money.moneyValue -= taxCost;
             taxCost += 30;
         }
    }

    public void CapacityUp()
    {
        if (money.moneyValue >= cost)
        {
            woodCarrier.plankCapacity += 10;
            money.moneyValue -= cost;
            cost += 20;
        }
        
    }

    public void ShopExit()
    {
        powerUpUIPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShopOn()
    {
        powerUpUIPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
