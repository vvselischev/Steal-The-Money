using UnityEngine;
using System.Collections.Generic;
using System;

public class CoinList : MonoBehaviour
{
    public List<GameObject> coins = new List<GameObject>();
    private List<Vector3> positions = new List<Vector3>();
    private int activeCoinsCount;

    public int ActiveCoinsCount
    {
        get
        {
            return activeCoinsCount;
        }
    }

    public int TotalCoinsCount
    {
        get
        {
            return coins.Count;
        }
    }

    public void Initialize()
    {
        activeCoinsCount = coins.Count;
        for (int i = 0; i < activeCoinsCount; i++)
        {
            positions.Add(coins[i].transform.position);
        }
    }

    public void ResetCoins()
    {
        activeCoinsCount = coins.Count;
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].SetActive(true);
            coins[i].transform.position = positions[i];
        }
    }

    public void RemoveCoin(GameObject coin)
    {
        coin.SetActive(false);
        activeCoinsCount--;
    }
}
