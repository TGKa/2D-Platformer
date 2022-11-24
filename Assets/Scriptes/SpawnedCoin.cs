using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedCoin : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private Coin _tamplate;
    [SerializeField] private Transform _container;

    private List<Transform> _points = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < _spawner.childCount; i++)
        {
            _points.Add(_spawner.GetChild(i));
        }

        SpawnCoin();
    }

    private void SpawnCoin()
    {
        foreach (var point in _points)
        {
            Instantiate(_tamplate, point.transform.position, Quaternion.identity,_container);
        }
    }
}
