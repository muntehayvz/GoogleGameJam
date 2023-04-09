using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }

    string scoreKey = "Score";
    public TMP_Text scoreText;
    public float transitionSpeed = 100;
    float displayScore;

    private void Awake()
    {
        if(Instance && Instance != this)
        {
            // Destroy myself
            Destroy(gameObject);
            return;
        }

        // Otherwise store my reference and make me DontDestroyOnLoad
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        displayScore = Mathf.MoveTowards(displayScore, Score, transitionSpeed * Time.deltaTime);
        UpdateScoreDisplay();

    }
   
    public void IncreaseScore(int amount)
    {
        Score += amount;
       
    }
    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("Score: {0:0}", displayScore);
    }
}
