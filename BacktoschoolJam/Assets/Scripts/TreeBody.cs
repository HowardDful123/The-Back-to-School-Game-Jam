using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBody : MonoBehaviour {
    public int health;

    public bool isDestroyed;

    private bool colorChanged;
    private SpriteRenderer sprite;
    private float timeElaspedColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
                colorChanged = false;
                ResetColor();
            }
        }
	}

    public void DealDamage()
    {
        health--;
        ChangeColor();
    }

    private void ChangeColor()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 0, 0, .7f);
        colorChanged = true;
    }

    private void ResetColor()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
}
