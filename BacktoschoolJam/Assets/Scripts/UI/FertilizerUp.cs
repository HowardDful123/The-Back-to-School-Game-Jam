using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FertilizerUp : MonoBehaviour {
    public TreesGrowth treeGrowth;
    public Transform imageLevel;
    public int level;

    public void levelUp()
    {
        ChangeLevelColor();
        if (level < 4)
        {
            level++;
            treeGrowth.GetComponent<TreesGrowth>().growSpeed -= 0.75f;
        }
    }

    public void ChangeLevelColor()
    {
        if (level < 4)
        {
            imageLevel.GetComponent<Transform>().GetChild(level).GetComponent<Image>().color = new Color(1f, 0, 0, .7f);
        }

    }
}
