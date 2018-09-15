using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour {
    public int moneyValue;
    public int taxAmount;

    public bool inDebt;
    private float debtCounter;

    // Use this for initialization
    void Start () {
        GetComponent<Transform>().GetChild(2).GetComponent<TextMeshProUGUI>().enabled = false;
        debtCounter = 250;
	}
	
	// Update is called once per frame
	void Update () {    
        debtCounter -= Time.deltaTime;
        GetComponent<Transform>().GetChild(3).GetComponent<TextMeshProUGUI>().text = "Collecting Tax In: " + (int)debtCounter;
        GetComponent<Transform>().GetChild(4).GetComponent<TextMeshProUGUI>().text = "Tax To Collect: $" + taxAmount;

        if (moneyValue < 0)
        {
            GetComponent<Transform>().GetChild(2).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            GetComponent<Transform>().GetChild(2).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (debtCounter <= 0)
        {
            CollectTax();
        }
    }

    public void CollectTax()
    {
        if (moneyValue < 0)
        {
            SceneManager.LoadScene("Lose");
        }
        moneyValue -= taxAmount;
        debtCounter = 200;
    }
}
