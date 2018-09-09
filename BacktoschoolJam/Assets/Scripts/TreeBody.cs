using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBody : MonoBehaviour {
    public int health;
    public Sprite cracked1, cracked2, cracked3;
    public bool isDestroyed;
    public int maxHealth;

    private bool colorChanged;
    private SpriteRenderer sprite;
    private float timeElaspedColor;

    // Use this for initialization
    void Start()
    {
        health = transform.GetComponentInParent<TreesGrowth>().globalHealth;
    }

    // Update is called once per frame
    void Update () {

        maxHealth = transform.GetComponentInParent<TreesGrowth>().globalHealth;

        if (health <= 0)
        {
            isDestroyed = true;
        }

        if (colorChanged)
        {
            timeElaspedColor += Time.deltaTime;
            if (timeElaspedColor >= 0.25f)
            {
                timeElaspedColor = 0;
                ResetColor();
                colorChanged = false;
            }
        }
	}

    public void DealDamage()
    {
        GetComponentInParent<AudioSource>().volume = Random.Range(0.7f, 1f);
        GetComponentInParent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        GetComponentInParent<AudioSource>().Play();
        health -= GetComponentInParent<TreesGrowth>().damage;
        ChangeColor();
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        if (health < maxHealth && health >= (maxHealth*0.75))
        {
            sr.sprite = cracked1;
        }
        if (health < (maxHealth*0.75) && health >= (maxHealth/2))
        {
            sr.sprite = cracked2;
        }
        if (health < (maxHealth/2))
        {
            sr.sprite = cracked3;
        }
        sr.color = new Color(1f, 0, 0, .7f);
        colorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    public void IncreaseHealth()
    {
        health += 2;
    }
}
