using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {
    public GameObject powerUpUIPanel;
    public Text capacityText;
    public Text capacityCost;
    public WoodCarrier woodCarrier;
    public Money money;
    public int cost;



    void Update()
    {
        capacityText.text = "Capacity: " + woodCarrier.plankNumber + "/" + woodCarrier.plankCapacity;    
        capacityCost.text = "Cost: " + cost;
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
