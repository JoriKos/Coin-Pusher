using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private ValueHolder _vh;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private List<Vector3> _spawnPosition;
    [SerializeField] private GameManagement _manager;

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
        GameObject newCoin = null;

        for (int i = 0; i < amount; i++)
        {
            if (_vh.Coins > 0)
            {
                for (int j = 0; j < _manager.Chance.Count; j++)
                {
                    if (Random.value <= (_manager.Chance[j] / 100))
                    {
                        newCoin = _vh.CoinPool[j].GetObject();
                        newCoin.GetComponent<CoinBase>().Type = (CoinType)j;
                        
                        //Break out of for loop
                        j = _manager.Chance.Count + 9999;
                    }
                }

                newCoin.transform.SetPositionAndRotation(_spawnPosition[Random.Range(0, _spawnPosition.Count)], Random.rotation);

                newCoin.SetActive(true);
                _vh.Coins -= 1;
                yield return new WaitForSeconds(1);
            }
        }
        yield return null;
    }
}