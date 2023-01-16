using TMPro;
using UnityEngine;

public class GameplayScores : MonoBehaviour
{
    private TextMeshProUGUI playerSpeedText;
    private int scores;

    void Start()
    {
        playerSpeedText = GetComponent<TextMeshProUGUI>();
        EventManager.OnEnemyKilled.AddListener(DisplayScores);
    }
    private void DisplayScores()
    {
        scores++;
        playerSpeedText.text = $"Scores:\n{scores}";
    }
}
