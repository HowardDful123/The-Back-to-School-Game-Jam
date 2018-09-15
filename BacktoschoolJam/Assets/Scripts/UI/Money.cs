using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMeshProUGUI>().text = "Money: $" + GetComponentInParent<MoneyManager>().moneyValue;
    }
}
