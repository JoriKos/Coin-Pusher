using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] private float _posOrigin, _posMax, _posMin, _speed;
    [SerializeField] private Rigidbody _pusherRigidbody;
    [SerializeField] private bool _moveForward;

    private void Awake()
    {
        _posOrigin = transform.position.x;
        _posMax = _posOrigin + _posMax;
        _posMin = _posOrigin - _posMin;
        _moveForward = true;
    }

    void FixedUpdate()
    {
        //_pusherRigidbody.MovePosition(Time.fixedDeltaTime * new Vector3(transform.position.x + 1, transform.position.y));
        //_pusherRigidbody.MovePosition(Time.fixedDeltaTime * new Vector3(transform.position.x - 1, transform.position.y));

        if (_moveForward)
            _pusherRigidbody.AddForce(_speed * Time.deltaTime * Vector3.right);
        else
            _pusherRigidbody.AddForce(_speed * Time.deltaTime * -Vector3.right);

        if (transform.position.x > _posMax)
        {
            _moveForward = false;
        }
        else if (transform.position.x < _posMin)
        {
            _moveForward = true;
        }
    }
}
