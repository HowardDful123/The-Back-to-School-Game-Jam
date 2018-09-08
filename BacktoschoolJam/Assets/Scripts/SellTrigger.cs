using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellTrigger : MonoBehaviour {
    public WoodCarrier woodCarrier;

    private TextMeshPro text;

    void Start()
    {
        text = this.GetComponentInChildren<TextMeshPro>();
        text.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SellText(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SellText(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void SellText(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.GetComponent<MeshRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                woodCarrier.SellPlank();
                Debug.Log("Selling Plank!!!!");
            }
        }
    }
}
