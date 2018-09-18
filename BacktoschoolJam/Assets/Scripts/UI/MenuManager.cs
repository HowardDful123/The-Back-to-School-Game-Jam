using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("Hao");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
