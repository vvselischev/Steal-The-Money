using UnityEngine;

public class Safe : MonoBehaviour
{
    private Rotator rotator;
    private Quaternion startRotation;

    public void Initialize()
    {
        //SetRotationAsDefault();
        rotator = GetComponent<Rotator>();
    }

    public void SetRotationAvailable(bool available)
    {
        rotator.enabled = available;
    }

    void Awake()
    {
        SetRotationAsDefault();
    }

    private void SetRotationAsDefault()
    {
        startRotation = transform.rotation;
    }

    public void ResetRotation()
    {
        transform.rotation = startRotation;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        Initialize();
        SetRotationAvailable(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
	
}
