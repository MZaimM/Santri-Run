using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText, poinTasbihText;

    public float scoreCount, poinCount;
    public float highScoreCount;

    public float publicPerSecond;

    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if(PlayerPrefs.GetFloat("Poin") != null){
            poinCount = PlayerPrefs.GetFloat("Poin");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += publicPerSecond * Time.deltaTime;
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        poinTasbihText.text = "" + Mathf.Round(poinCount);

        scoreText.text = "" + Mathf.Round(scoreCount);
        highScoreText.text = "High Score : " + Mathf.Round(highScoreCount);
    }

    public void AddScore (int pointsToAdd){
        poinCount += pointsToAdd;
        PlayerPrefs.SetFloat("Poin", poinCount);
    }
}
