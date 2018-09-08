using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour {
    public PowerUpManager powerUpManager;

    private TextMeshPro text;
    // Use this for initialization
    void Start () {
        text = this.GetComponentInChildren<TextMeshPro>();
        text.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ShopText(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShopText(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void ShopText(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.GetComponent<MeshRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                powerUpManager.ShopOn();
            }
        }
    }
}
