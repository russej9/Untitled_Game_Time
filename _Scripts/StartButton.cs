using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour{

    public AudioSource audioSource;
    public AudioClip gameMusic;

    public void Awake()
    {
        Time.timeScale = 0; //when game starts nothing will be moving
    }

    public void StartGame()
    {
        transform.localScale = Vector3.zero; //just scale ui elements to zero, not enable/disable as it saves on processing power
        Time.timeScale = 1f; //when the start button is pressed everything will start

        if(audioSource && gameMusic)
        {
            audioSource.clip = gameMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

}
