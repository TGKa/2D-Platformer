using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _recharge;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;

    private const string _trigerAttack = "Attack";

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
            _animator.SetTrigger(_trigerAttack);
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _timePassedAfterShot = 0;
        }
    }
}
