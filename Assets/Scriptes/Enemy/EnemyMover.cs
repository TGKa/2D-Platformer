using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;
    private List<Transform> _points = new List<Transform>();
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        for (int i = 0; i < _path.childCount; i++)
        {
            _points.Add(_path.GetChild(i));
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position.x < target.position.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Count)
                _currentPoint = 0;
        }
    }
}
