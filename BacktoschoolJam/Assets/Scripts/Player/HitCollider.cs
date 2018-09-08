using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            TreeBody treebody = collision.transform.GetComponent<TreeBody>();
            treebody.DealDamage();
            Debug.Log("Dealing Damage");
        }
        if (collision.gameObject.CompareTag("treeTop"))
        {
            TreeTop treetop = collision.transform.GetComponent<TreeTop>();
            treetop.DealDamage();
            Debug.Log("Dealing Damage");
        }
    }

}
