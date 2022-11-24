using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private bool _isGround;
    private bool _isJumping;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Run(-_speed, true);
        }

            if (Input.GetKey(KeyCode.D))
        {
            Run(_speed, false);
        }

        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            _isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
        _isJumping = true;
    }

    public void PlayAnimationHit()
    {
        _animator.SetBool("Run", false);
        _animator.SetTrigger("Hit");
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _animator.SetBool("Run", false);
            _animator.SetTrigger("Jump");
            _rigidbody2D.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
        }
    }

    private void Run(float speed, bool isRotatedAnimation = false)
    {
        if (_isJumping)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = isRotatedAnimation;
        }
        else
        {
            _animator.SetBool("Run", true);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = isRotatedAnimation;
        }
    }
}
