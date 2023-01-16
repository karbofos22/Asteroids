using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPositionRotationStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerSpeedText;
    [SerializeField] private TextMeshProUGUI playerRotationText;
    [SerializeField] private TextMeshProUGUI playerPostionText;

    void Start()
    {
        EventManager.OnPlayerTransformAndSpeedChange.AddListener(DisplayPlayerTransformAndSpeedStatus);
    }

    private void DisplayPlayerTransformAndSpeedStatus(Transform player, float speed)
    {
        playerSpeedText.text = $"Speed:\n{speed}";
        playerRotationText.text = $"Rotation:\n{Mathf.Round(player.eulerAngles.z)}";
        playerPostionText.text = $"Position:\nX: {Mathf.Round(player.position.x)}, Y:{Mathf.Round(player.position.y)}";
    }
}
