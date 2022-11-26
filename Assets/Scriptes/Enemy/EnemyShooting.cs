using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float _recharge;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;

    private const string _trigerAttack = "Attack";

    private Animator _animator;
    private Coroutine _shooting;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _shooting = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var recharge = new WaitForSeconds(_recharge);

        while (true)
        {
            _animator.SetTrigger(_trigerAttack);
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);

            yield return recharge;
        }
    }
}
