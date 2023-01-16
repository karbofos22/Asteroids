using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        GetReady,
        GameActive,
        Win,
        Lose
    }
    private GameState state;

    void Start()
    {
        UpdateGameState(GameState.Menu);

        EventManager.OnLose.AddListener(ChangeGameStateOnLose);
        EventManager.OnStart.AddListener(ChangeGameStateOnGameActive);
        EventManager.OnRestart.AddListener(ChangeGameStateOnMenu);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        EventManager.SendGameStateChanged(state);
    }
    private void ChangeGameStateOnGameActive()
    {
        UpdateGameState(GameState.GameActive);
    }
    private void ChangeGameStateOnLose()
    {
        UpdateGameState(GameState.Lose);
    }
    private void ChangeGameStateOnMenu()
    {
        UpdateGameState(GameState.Menu);
    }
}
