using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour
{

    private CharacterStatus stat;
    private Text myText;
    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        stat = GameObject.FindWithTag("Player").GetComponent<CharacterStatus>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int interval = 10; //this shoudl keep update running 30/10 = 3 times per second
        if (Time.frameCount % interval == 0)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                string currentHighScoreString = PlayerPrefs.GetString("High Score");
                float currentHighScore = 0;
                float currentScore = stat.getCharScore();
                float.TryParse(currentHighScoreString, out currentHighScore);
                if (currentScore > currentHighScore)
                {
                    currentHighScore = currentScore;
                }
                myText.text = "High Score: " + currentHighScore.ToString();// + currentHighScore.ToString();//PlayerPrefs.GetString("High Score");
                PlayerPrefs.SetString("High Score", currentHighScore.ToString());
                PlayerPrefs.Save();
            }
        }
    }
}
