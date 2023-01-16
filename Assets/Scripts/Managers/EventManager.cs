using UnityEngine;
using UnityEngine.Events;
using static GameStateManager;

public class EventManager
{
    public static UnityEvent OnEnemyKilled = new();
    public static UnityEvent<GameState> OnGameStateChanged = new();
    public static UnityEvent OnStart = new();
    public static UnityEvent OnRestart = new();
    public static UnityEvent OnLose = new();

    public static UnityEvent<Transform, float> OnPlayerTransformAndSpeedChange = new();
    public static UnityEvent<float, int> OnLaserShot = new();
    public static UnityEvent<int, int> OnGameOver = new();

    public static void SendPlayerTransformAndSpeed(Transform player, float speed)
    {
        OnPlayerTransformAndSpeedChange.Invoke(player, speed);
    }
    public static void SendLaserShotStatus(float reloadTime, int shotsCount)
    {
        OnLaserShot.Invoke(reloadTime, shotsCount);
    }
    public static void SendScoresOnGameOver(int scores, int totalScores)
    {
        OnGameOver.Invoke(scores, totalScores);
    }
    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
    public static void SendGameStateChanged(GameState newState)
    {
        OnGameStateChanged.Invoke(newState);
    }
    public static void SendStart()
    {
        OnStart.Invoke();
    }
    public static void SendRestart()
    {
        OnRestart.Invoke();
    }
    public static void SendLose()
    {
        OnLose.Invoke();
    }
}
