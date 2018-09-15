using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenManager : MonoBehaviour {

    public void PlayAgain()
    {
        SceneManager.LoadScene("Hao");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
