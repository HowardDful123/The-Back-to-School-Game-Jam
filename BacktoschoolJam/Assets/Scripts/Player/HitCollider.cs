using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            TreeBody treebody = collision.transform.GetComponent<TreeBody>();
            treebody.DealDamage();
            Debug.Log("Dealing Damage");
        }
    }
}
