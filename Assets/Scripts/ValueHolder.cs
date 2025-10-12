using Unity.VisualScripting;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    [SerializeField] private float _coins;
    [SerializeField] private ObjectPooling _coinPool;
    public float Coins { get { return _coins; } set { _coins = value; } }
    public ObjectPooling CoinPool { get { return _coinPool; } }

    private void Awake()
    {
        _coinPool = GameObject.Find("CoinPool").GetComponent<ObjectPooling>();
    }
}
