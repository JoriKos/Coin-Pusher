using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    [SerializeField] private float _coins, _premiumCoins;
    [SerializeField] private List<ObjectPooling> _coinPool;
    public float Coins { get { return _coins; } set { _coins = value; } }
    public float PremiumCoins { get { return _premiumCoins; } set { _premiumCoins = value; } }
    public List<ObjectPooling> CoinPool { get { return _coinPool; } }

    private void Awake()
    {
        string[] coinTypeNames = Enum.GetNames(typeof(CoinType));

        for (int i = 0; i < coinTypeNames.Length; i++)
        {
            _coinPool.Add(GameObject.Find("Pool_" + coinTypeNames[i]).GetComponent<ObjectPooling>());
        }
    }
}
