using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    public GameObject powerUpUIPanel;
    public WoodCarrier woodCarrier;

    private static bool isOnUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOnUI)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void CapacityUp()
    {
        woodCarrier.plankCapacity += 10;
    }

    public void Resume()
    {
        powerUpUIPanel.SetActive(false);
        isOnUI = false;
    }

    public void Paused()
    {
        powerUpUIPanel.SetActive(true);
        isOnUI = true;
    }
}
