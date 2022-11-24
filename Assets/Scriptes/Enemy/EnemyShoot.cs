using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _recharge;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;

    private Animator _animator;
    private float _timePassedAfterShot;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _timePassedAfterShot += Time.deltaTime;

        if(_timePassedAfterShot >= _recharge)
        {
            _animator.SetTrigger("Attack");
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _timePassedAfterShot = 0;
        }
    }
}
