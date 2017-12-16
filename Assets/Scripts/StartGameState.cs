using UnityEngine;

public class StartGameState : MonoBehaviour
{
    public Canvas StartCanvas;
    public LevelManager levelManager;

    public void InvokeState()
    {
        levelManager.InitializeLevels();
    }

    public void StartButtonClicked()
    {
        StartCanvas.enabled = false;
        gameObject.GetComponent<PlayState>().InvokeState();
    }
}
