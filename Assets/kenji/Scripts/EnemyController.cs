using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyController : CharacterBase
{
    GameObject _player = default;    //プレイヤー
    //plaerの攻撃を引っ張る
    /// <summary>この範囲にプレイヤーがいる場合、プレイヤーを見つけることができる</summary>
    [SerializeField] float m_playerSearchRangeRadius = 5f;
    /// <summary>動く速さ</summary>
    [SerializeField] float _speed = 2f;
    // ジャンプする力
    [SerializeField] float _jumpPower = 15f;
    /// <summary>初期のジャンプ回数のリミット</summary>
    [SerializeField] int _jumpLimit = 1;
    Rigidbody2D _rb = default;
    /// <summary>アイテムをドロップさせるために</summary>
    [SerializeField] GameObject _itemPrefab = default;
    private bool _isGrounded = false;
    private int _jumpInterval = 1;



    int x = 0;
    int y = 0;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Invoke("Jump", Random.Range(_jumpInterval, 2f));
    }
    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        _jumpLimit++;
    }


    // Update is called once per frame
    void Update()
    {

        if (_player)
        {
            Vector2 dir = _player.transform.position - this.transform.position;
            if (Mathf.Abs(_player.transform.position.x - this.transform.position.x) > float.Epsilon)
            {
                x = _player.transform.position.x > this.transform.position.x ? 1 : -1;
            }

            if (Mathf.Abs(_player.transform.position.y - this.transform.position.y) > float.Epsilon)
            {
                y = _player.transform.position.y > this.transform.position.y ? 1 : -1;
            }
            else // プレイヤーが見つからない場合はランダムに移動する
            {
                x = Random.Range(-1, 0);
                y = Random.Range(-1, 0);
            }
        }
        
        Death();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpLimit = 0;
            _isGrounded = true;
            Random.Range(0, _jumpLimit);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            // CharacterBase characterBase = collision.gameObject.GetComponent<CharacterBase>();
            // characterBase.Damage(5);[
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _isGrounded = false;
    }

    private void Death()
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Result");
        }
    }
    private void OnDestroy()
    {
        Instantiate(_itemPrefab,transform.position, Quaternion.identity);    
    }
}
