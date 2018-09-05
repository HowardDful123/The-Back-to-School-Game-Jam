using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTrigger : MonoBehaviour {
    public WoodCarrier woodCarrier;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider"))
        {
            woodCarrier.SellPlank();
            Debug.Log("Selling LOGGGGGssss");
        }
    }
}
