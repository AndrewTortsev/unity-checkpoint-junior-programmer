using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public float secondsToAddScore;
    private static string text = "Score: {0} Best result: {1}";
    private delegate void AddScoreTask();
    private AddScoreTask addScoreTask;
    public int CurrentPlayerScore { get; private set; }

    void Start()
    {
        addScoreTask = AddPoint;
        InvokeRepeating(addScoreTask.Method.Name, 2f, secondsToAddScore);
    }

    void Update()
    {
        scoreLabel.text = GetFormatedText();
        if (GameManager.INSTANCE.IsGameOver)
        {
            CancelInvoke(addScoreTask.Method.Name);
            GameManager.INSTANCE.CompareAndSaveUserData(CurrentPlayerScore);
        }
    }

    private string GetFormatedText()
    {
        return string.Format(text, CurrentPlayerScore, GameManager.INSTANCE.BestPlayerScore);
    }

    private void AddPoint()
    {
        CurrentPlayerScore++;
    }
}
