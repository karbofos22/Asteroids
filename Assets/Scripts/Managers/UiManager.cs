using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateManager;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject gameplayScreen;

    private void Awake()
    {
        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }
    private void OnGameStateChanged(GameState state)
    {
        menuScreen.SetActive(state == GameState.Menu);
        gameplayScreen.SetActive(state == GameState.GameActive);
        loseScreen.SetActive(state == GameState.Lose);
    }
}
