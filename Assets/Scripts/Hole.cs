using UnityEngine;
using System.Collections;
using System;

public class Hole : MonoBehaviour
{
    public CoinList coinManager;
    public WinLevelState winLevelState;
    public ParticleSystem effector;
    private CircleCollider2D circleCollider;

    public event EventHandler onDrop;

    private void Initialize()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void Activate()
    {
        Initialize();
        circleCollider.enabled = true;
    }

    public void Deactivate()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        effector.Play();
        onDrop(other.gameObject, null);          
    }
}
