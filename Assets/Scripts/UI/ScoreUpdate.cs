using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        SetUi();    
    }

    public void IncreaseScore()
    {
        score++;
        SetUi();
    }

    private void SetUi()
    {
        scoreText.text = score.ToString();
    }
}
