using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShooting : MonoBehaviour
{
    private const string TrigerAttack = "Attack";

    [SerializeField] private float _recharge;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;    

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
            _animator.SetTrigger(TrigerAttack);
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);

            yield return recharge;
        }
    }
}
