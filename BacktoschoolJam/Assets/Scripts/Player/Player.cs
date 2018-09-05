using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5;

    private Rigidbody2D rb;
    private BoxCollider2D hitCollider;
    private bool isAttack;
    public float delaytime;
    private float delayspeed;
    private bool attackDelay;
    public float attackSpeed; 
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        hitCollider = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (isAttack)
        {
            attackSpeed += Time.deltaTime;
            if (attackSpeed >= 0.2f)
            {
                attackSpeed = 0;
                isAttack = false;
                hitCollider.enabled = false;
                attackDelay = true;
            }
            Debug.Log(attackDelay);
        }
        if (attackDelay)
        {
            delayspeed += Time.deltaTime;
            if (delayspeed >= delaytime)
            {
                attackDelay = false;
                delayspeed = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attackDelay != true)
            {
                Attack();
            }
        }

    }

    public void Attack()
    {
        hitCollider.enabled = true;
        isAttack = true;
    }
}
