using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{

   public void Awake()
   {
       Time.timeScale = 0; //when game starts nothing will be moving
   }

   public void StartGame()
   {
       transform.localScale = Vector3.zero; //just scale ui elements to zero, not enable/disable as it saves on processing power
       Time.timeScale = 1f; //when the start button is pressed everything will start

   }

    public void QuitGame()
    {
        Application.Quit();
    }

}
