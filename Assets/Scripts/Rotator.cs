using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int velocity = 1;
	
	void Update ()
    {
        transform.Rotate(0, 0, -Input.acceleration.x * 1.5f);

        if (Input.GetButton("Left"))
            transform.Rotate(0, 0, velocity);
        if (Input.GetButton("Right"))
            transform.Rotate(0, 0, -velocity);
    }
}
