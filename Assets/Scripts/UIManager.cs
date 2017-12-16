using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    private Text textClone;

    public float maxScale = 3;

    public ScoreManager scoreManager;
    public LevelManager levelManager;
    public Canvas PlayCanvas;

    void Start()
    {
        PlayCanvas.enabled = false;
    }

    public void DisableAll()
    {
        PlayCanvas.enabled = false;
        levelManager.CurrentLevel.timerManager.timeText.enabled = false;
    }

    public void PerformLerpString(string s, Color color)
    {
        textClone = text;
        textClone.color = new Color(color.r, color.g, color.b);
        textClone.rectTransform.localScale = new Vector3(1, 1, 1);
        textClone.text = s;
        textClone.enabled = true;
        StartCoroutine(ScaleTextCoroutine());
    }

    IEnumerator ScaleTextCoroutine()
    {
        while (true)
        {
            textClone.rectTransform.localScale = Vector3.Lerp(textClone.rectTransform.localScale, 
                new Vector3(maxScale, maxScale, maxScale), Time.deltaTime);
            yield return null;
        }
    }

    public void DisableText()
    {
        StopCoroutine(ScaleTextCoroutine());
        textClone.enabled = false;
    }
}
