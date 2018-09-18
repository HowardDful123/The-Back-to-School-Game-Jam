using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextImport : MonoBehaviour {
    public TextAsset textfile;
    public string[] textlines;

    private float textCounter;

    void Start () {
        if (textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }

        GetComponent<TextMeshProUGUI>().text = textlines[Random.Range(0, textlines.Length - 1)];
	}
	
	// Update is called once per frame
	void Update () {
        textCounter += Time.deltaTime;
        if (textCounter >= 4)
        {
            GetComponent<TextMeshProUGUI>().text = textlines[Random.Range(0, textlines.Length - 1)];
            textCounter = 0;
        }

	}
}
