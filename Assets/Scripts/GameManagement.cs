using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [Range (1, 100)]
    [SerializeField] private List<float> _chance; //Corresponds to enum CoinType in SpecialCoin.cs
    [SerializeField] private float _valueMultiplier;

    public List<float> Chance { get { return _chance; } set { _chance = value; } }

    public float ValueMultiplier { get { return _valueMultiplier; } set { _valueMultiplier = value; } }

    private void Awake()
    {
        if(_valueMultiplier < 0)
        {
            _valueMultiplier = 1;
        }
    }
}
