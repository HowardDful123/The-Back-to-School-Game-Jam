using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSound : MonoBehaviour {
    public AudioSource windSound;
    // Use this for initialization
    void Start () {
        windSound.volume = Random.Range(0.6f, 0.8f);
        windSound.pitch = Random.Range(0.7f, 1.1f);
        windSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (windSound.isPlaying == false)
        {
            windSound.volume = Random.Range(0.6f, 0.8f);
            windSound.pitch = Random.Range(0.7f, 1.1f);
            windSound.Play();
        }
	}
}
