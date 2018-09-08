using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5;
    public float attackSpeed;
    public float delaytime;

    private Animator playerAnimation;
    private bool isAttack;
    private bool isAttackAnimation;
    private Rigidbody2D rb;
    private BoxCollider2D hitCollider;
    private float delayspeed;
    private bool attackDelay;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        hitCollider = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);

            playerAnimation.SetFloat("move", Mathf.Abs(speed));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            playerAnimation.SetFloat("move", Mathf.Abs(speed));
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            playerAnimation.SetFloat("move", 0);
        }

        if (isAttack)
        {
            attackSpeed += Time.deltaTime;
            AttackAnimation();
            ResetAnimation();
            if (attackSpeed >= 0.05f)
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
        isAttackAnimation = true;
    }

    private void AttackAnimation()
    {
        if (isAttackAnimation)
        {
            playerAnimation.SetTrigger("attack");
        }
    }
    private void ResetAnimation()
    {
        isAttackAnimation = false;
    }
}
