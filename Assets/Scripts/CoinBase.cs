using UnityEngine;

public class CoinBase : MonoBehaviour
{
    [SerializeField] private ValueHolder _vh;
    [SerializeField] private float _value, _weightMultiplier;
    [SerializeField] private GameManagement _manager;
    [SerializeField] private CoinType _type; //Set in prefab
    public float WeightMultiplier { get { return _weightMultiplier; } set { _weightMultiplier = value; } }

    public CoinType Type { get { return _type; } set { _type = value; } }

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _vh = GameObject.Find("GameManager").GetComponent<ValueHolder>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManagement>();

        if (_weightMultiplier == 0)
            _weightMultiplier = 1;

        _rb.mass *= _weightMultiplier;

        // If lower than 0, set to 0. If higher than 0.25, set to 0.25. Else, use current mass.
        _rb.mass = (_rb.mass < 0) ? 0 : (_rb.mass > 0.25f) ? 0.25f : _rb.mass;

        _rb.linearVelocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //We add value here
        if (other.name == "CoinReceiver")
        {
            int index = (int)_type;
            float valueToAdd;

            valueToAdd = (_type == CoinType.Double) ? (_value * _manager.ValueMultiplier) * 2 : _value * _manager.ValueMultiplier;

            valueToAdd = Mathf.Round(valueToAdd);

            _vh.Coins += valueToAdd;
            _vh.CoinPool[index].ReturnObject(gameObject);
        }
    }

    private void OnEnable()
    {
        _rb.linearVelocity = new Vector3(0, 0, 0);
    }

}