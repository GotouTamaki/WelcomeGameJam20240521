using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : CharacterBase
{
    // 左右移動する力
    [SerializeField] float _moveSpeed = 5f;

    // ジャンプする力
    [SerializeField] float _jumpPower = 15f;

    /// <summary>初期のジャンプ回数のリミット</summary>
    [SerializeField] int _jumpCountLimit = 1;

    #region 各種初期化

    Rigidbody2D _rigidbody2D;
    SpriteRenderer _sprite;

    // 水平方向の入力値
    float _h;
    bool _lookingRight = true;

    // ジャンプの入力値
    int _jumpCount;
    bool _isGrounded;

    #endregion

    public bool LookingRight => _lookingRight;
    public float HorizontalInput => _h;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxis("Horizontal"); //入力方向をfloat型で取得

        if (Input.GetButtonDown("Jump") && (_isGrounded || _jumpCount < _jumpCountLimit)) //押したことを判定
        {
            // ジャンプの力を加える
            _rigidbody2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCount++;
        }

        // 入力に応じて左右を反転させる
        FlipX(_h);

        if (IsDead)
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(Vector2.right * _h * _moveSpeed, ForceMode2D.Force);
    }

    void FlipX(float horizontal)
    {
        //画像フリップ処理
        if (horizontal > 0)
        {
            //右を向いてるかのフラグ
            _lookingRight = true;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            //右を向いてるかのフラグ
            _lookingRight = false;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        //_sprite.flipX = horizontal < 0;
        //右を向いてるかのフラグ
        //_lookingRight = horizontal > 0;
    }

    private void Death()
    {
        SceneManager.LoadScene("Clear");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isGrounded = false;
    }
}