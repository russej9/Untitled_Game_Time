using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour{

    public FloatVariable score;
    public FloatVariable highScore;

    public BoolVariable playerAlive;

    public Image medalImage;

    public Sprite bronzeStar;
    public Sprite silverStar;
    public Sprite goldStar;

    public int goldMinScore;
    public int silverMinScore;

    public Text newHighScoreLabel;

    bool visible;

    private void Awake()
    {
        transform.localScale = Vector3.zero; //will automatically set scale to zero so while setting stuff up don't have to do it manually
        score.SetValue(0); //resets the player's score to 0

        if (PlayerPrefs.HasKey("HighScore"))
        {  //this can be used to store player preferences but can also store user data like high scores, players cna change this though
            highScore.value = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerAlive.value == true)
        {
            if(Time.timeScale > 0f)
            {
                score.ApplyChange(Time.deltaTime * 100); //means you get 100 points a second
            }
        }
        else if(!visible)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        visible = true;

        Time.timeScale = 0f;

        if(score.value > goldMinScore) //checking score for medals
        {
            medalImage.sprite = goldStar;
        }
        else if(score.value > silverMinScore)
        {
            medalImage.sprite = silverStar;
        }
        else
        {
            medalImage.sprite = bronzeStar;
        }

        if(score.value < highScore.value)
        {
            newHighScoreLabel.transform.localScale = Vector3.zero; //hides the high score label
        }
        else if(score.value > highScore.value)
        {
            highScore.SetValue(score.value);
            PlayerPrefs.SetFloat("HighScore", score.value);
        }

        transform.localScale = Vector3.one; //.one is the default scale of every object
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //just in case scene name is different, will get whatever the active scene is
    }
}
