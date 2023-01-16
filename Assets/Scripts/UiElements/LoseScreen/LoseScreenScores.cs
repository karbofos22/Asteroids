using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseScreenScores : MonoBehaviour
{
    private TextMeshProUGUI scoresText;

    void Start()
    {
        scoresText = GetComponent<TextMeshProUGUI>();
        EventManager.OnGameOver.AddListener(DisplayTotalScores);

    }
    private void DisplayTotalScores(int currentScores, int totalScores)
    {
        scoresText.text = $"This session scores: {currentScores}\nTotal scores: {totalScores}";
    }
}
