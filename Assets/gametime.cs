using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gametime : MonoBehaviour
{
    public Text counterText;
    //varialbes for time display
    public float days, months, year, frames;

 
    public void Timerbutton()
    {
        counterText = GetComponent<Text>() as Text;
        days = 1; // sets day to 1 on click
        months = 1; // sets months to 1 on click 
        year = 1; // sets year to 1 on click 
        frames = 1; // sets frames count to 1 on click 
        counterText.text = months.ToString("00") + "-" + days.ToString("00") + "-" + year.ToString("0000"); // resets what is displayed on click 
    }

    // Update is called once per frame
    void Update()
    {
        // makes the time update once per 60 frames
        if (frames < 60)
        {
            frames++;
        }
        else  //updating the time
        {
            frames = 1; // reset frame count
            if (months == 1 || months == 3 || months == 5 || months == 7 || months == 8 || months == 10) // counting days for months with 31 days
            {
                if(days < 31)
                {
                    days++;
                }
                else
                {
                    days = 1;
                    months++;
                }
            }
            else if (months == 2) // counting days for Feb
            {
                if (days < 28)
                {
                    days++;
                }
                else
                {
                    days = 1;
                    months++;
                }
            }
            else if (months == 12) // counting for Dec and then month reset
            {
                if(days < 31)
                {
                    days++;
                }
                else
                {
                    days = 1;
                    months = 1;
                    year++;
                }
            }
            else // counting for months with 30 days
            {
                if (days < 30)
                {
                    days++;
                }
                else
                {
                    days = 1;
                    months++;
                }
            }

            counterText.text = months.ToString("00") + "-" + days.ToString("00") + "-" + year.ToString("0000"); // displaying the time with update
        }
    }


}
