using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private ValueHolder _vh;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private List<Vector3> _spawnPosition;

    private void Awake()
    {
        _vh = GameObject.Find("GameManager").GetComponent<ValueHolder>();

        for (int i = 0; i < 4; i++)
        {
            _spawnPosition.Add(GameObject.Find("Spawn_" + i).transform.position);
        }
    }

    public void ButtonCoinSpawner(int amount = 1)
    {
        StartCoroutine(SpawnCoin(amount));
    }

    public IEnumerator SpawnCoin(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            if (_vh.Coins > 0)
            {
                GameObject newCoin = _vh.CoinPool.GetObject();
                newCoin.transform.SetPositionAndRotation(_spawnPosition[Random.Range(0, _spawnPosition.Count)], Random.rotation);
                _vh.Coins -= 1;
                yield return new WaitForSeconds(1);
            }

        }

        yield return null;
    }
}
