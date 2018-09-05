using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSpeedUp : MonoBehaviour {
    public Player player;
    public Transform imageLevel;
    public int level;

    public void levelUp()
    {
        ChangeLevelColor();
        level++;
        player.GetComponent<Player>().delaytime -= 0.25f;
    }

    public void ChangeLevelColor()
    {
        if (level < 4)
        {
            imageLevel.GetComponent<Transform>().GetChild(level).GetComponent<Image>().color = new Color(1f, 0, 0, .7f);
        }

    }


}
