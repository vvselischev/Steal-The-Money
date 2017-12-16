using UnityEngine;

public class StateManager : MonoBehaviour
{
    private GameState currentState;
    public PlayState playState;
    public StartGameState startState;

    void Start()
    {
        startState.InvokeState();
    }

    public GameState CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
        }
    }
}
