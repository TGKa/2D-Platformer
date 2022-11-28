using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    private const string TriggerJump = "Jump";
    private const string TriggerHit = "Hit";
    private const string TriggerRun = "Run";

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
            Run(-_speed, true);

        if (Input.GetKey(KeyCode.D))
            Run(_speed, false);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            Jump();

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            StopAnimationRun();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
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
        StopAnimationRun();
        _animator.SetTrigger(TriggerHit);
    }

    private void Jump()
    {
            StopAnimationRun();
            _animator.SetTrigger(TriggerJump);
            _rigidbody2D.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
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
            _animator.SetBool(TriggerRun, true);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = isRotatedAnimation;
        }
    }

    private void StopAnimationRun()
    {
        _animator.SetBool(TriggerRun, false);
    }
}
