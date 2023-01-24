using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    // UI Text GameObjects
    public GameObject playerOneScore;
    public GameObject playerTwoScore;

    // Text Components
    TextMeshProUGUI pOneScoreText;
    TextMeshProUGUI pTwoScoreText;

    void Start()
    {
        pOneScoreText = playerOneScore.GetComponent<TextMeshProUGUI>();
        pTwoScoreText = playerTwoScore.GetComponent<TextMeshProUGUI>();
    }

    void UpdatePlayerOneScore(int score)
    {
        pOneScoreText.text = score.ToString();
    }

    void UpdatePlayerTwoScore(int score)
    {
        pTwoScoreText.text = score.ToString();
    }
}