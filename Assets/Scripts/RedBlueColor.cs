using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RedBlueColor : MonoBehaviour
{
    public Text text;
    private float red;
    private float blue;

    private bool fromRedToBlue;
    // Use this for initialization

    /*void OnEnable()
    {
        PerformLerpColor();
    }*/

    public void PerformLerpColor()
    {
        
        StartCoroutine(LerpColorCoroutine());
        
    }

    IEnumerator LerpColorCoroutine()
    {
        red = 128;
        blue = 0;
        fromRedToBlue = true;
        while (true)
        {

            if (red >= 250)
            {
                fromRedToBlue = true;
                red = 250;
                blue = 0;
            }
            if (red <= 150)
            {
                fromRedToBlue = false;
                red = 150f;
                blue = 250;
            }

            if (!fromRedToBlue)
            {
                red += 0.1f;
                blue -= 0.1f;
            }
            else
            {
                red -=  0.1f;
                blue += 0.1f;
               
            }
            text.color = new Color(red, 0, blue);
            yield return null;
        }
    }

    /*public void StopLerpColor()
    {
        StartCoroutine(LerpColorCoroutine());
    }*/
}
