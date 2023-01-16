using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameStateManager;

public class PlayerController : MonoBehaviour
{
    private PlayerData playerData;
    private int scores;

    [SerializeField] private ParticleSystem explosionParticle;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerData = DataBase.GetData();
    }
    private void OnDisable()
    {
        DataBase.SaveData(playerData);
    }
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
        EventManager.OnEnemyKilled.AddListener(IncreaseTotalScores);
    }
    private void IncreaseTotalScores()
    {
        scores++;
        playerData.Scores++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AsteroidPart>() || 
            collision.gameObject.GetComponent<BigAsteroid>() ||
            collision.gameObject.GetComponent<AlienShip>())
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            
            EventManager.SendLose();
            Invoke(nameof(SendScores), 0.1f);
            Destroy(gameObject, 0.12f);
        }
    }
    private void OnGameStateChanged(GameState state)
    {
        playerInput.enabled = (state == GameState.GameActive);
    }
    private void SendScores()
    {
        EventManager.SendScoresOnGameOver(scores, playerData.Scores);
    }
}
