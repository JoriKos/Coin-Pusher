using UnityEngine;

public class CoinBase : MonoBehaviour
{
    [SerializeField] private ValueHolder _vh;
    [SerializeField] private float _value, _weightMultiplier;
    public float WeightMultiplier { get { return _weightMultiplier; } set { _weightMultiplier = value; } }

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _vh = GameObject.Find("GameManager").GetComponent<ValueHolder>();

        if (_weightMultiplier == 0)
            _weightMultiplier = 1;

        _rb.mass *= _weightMultiplier;

        // If lower than 0, set to 0. If higher than 0.25, set to 0.25. Else, use current mass.
        _rb.mass = (_rb.mass < 0) ? 0 : (_rb.mass > 0.25f) ? 0.25f : _rb.mass;

        _rb.linearVelocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CoinReceiver")
        {
            _vh.Coins += _value * _vh.ValueMultiplier;
            _vh.CoinPool.ReturnObject(gameObject);
        }

    }

    private void OnEnable()
    {
        _rb.linearVelocity = new Vector3(0, 0, 0);
    }

}