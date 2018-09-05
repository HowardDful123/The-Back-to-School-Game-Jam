using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthIndicator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = "Health: " + GetComponentInParent<TreeBody>().health;
	}
}
