using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TreeTop : MonoBehaviour {
    public int health;
    public Sprite cracked1, cracked2, cracked3;
    public TreesGrowth treesGrowth;

    private bool colorChanged;
    public int maxHealth;
    private float timeElaspedColor;
    // Use this for initialization
    void Start () {
        health = treesGrowth.globalHealth;
    }
	
	// Update is called once per frame
	void Update () {
        maxHealth = treesGrowth.globalHealth;

        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
            Destroy(this.gameObject);
        }

        GetComponentInChildren<TextMeshPro>().text = "Health: " + health;

        if (colorChanged)
        {
            timeElaspedColor += Time.deltaTime;
            if (timeElaspedColor >= 0.25f)
            {
                timeElaspedColor = 0;
                colorChanged = false;
                ResetColor();
            }
        }
    }

    public void DealDamage()
    {
        treesGrowth.GetComponent<AudioSource>().volume = Random.Range(0.7f, 1f);
        treesGrowth.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        treesGrowth.GetComponent<AudioSource>().Play();
        health -= treesGrowth.damage;
        ChangeColor();
    }

    private void ChangeColor()
     {
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        if (health < maxHealth && health > (maxHealth*0.75))
        {
            sr.sprite = cracked1;
        }
        if (health <= (maxHealth*0.75) && health >= (maxHealth/2))
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
        SpriteRenderer sr = this.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    public void IncreaseHealth()
    {
        health += 2;
    }
}
