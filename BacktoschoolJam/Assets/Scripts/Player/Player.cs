using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5;
    public float attackSpeed;
    public float delaytime;
    public AudioSource walking;

    private bool isWallking;
    private Animator playerAnimation;
    private bool isAttack;
    private bool isAttackAnimation;
    private Rigidbody2D rb;
    private BoxCollider2D hitCollider;
    private float delayspeed;
    private bool attackDelay;


    // Use this for initialization
    void Start () {
        walking = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        hitCollider = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {


        if (isWallking && walking.isPlaying == false)
        {
            walking.volume = Random.Range(0.3f, 0.6f);
            walking.pitch = Random.Range(0.7f, 1.1f);
            walking.Play();
        }


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            playerAnimation.SetFloat("move", Mathf.Abs(speed));
            isWallking = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            playerAnimation.SetFloat("move", Mathf.Abs(speed));
            isWallking = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            playerAnimation.SetFloat("move", 0);
            isWallking = false;
            walking.Stop();
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
