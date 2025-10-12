using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] private float _time;
    private float _internalTime;

    void Update()
    {
        _internalTime += Time.deltaTime;
        
        if (_internalTime > _time)
        {
            gameObject.SetActive(false);
        }
    }
}
