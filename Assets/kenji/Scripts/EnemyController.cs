using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterBase
{
    GameObject _player = default;    //プレイヤー
    //plaerの攻撃を引っ張る
    /// <summary>この範囲にプレイヤーがいる場合、プレイヤーを見つけることができる</summary>
    [SerializeField] float m_playerSearchRangeRadius = 5f;
    /// <summary>動く速さ</summary>
    [SerializeField] float _speed = 2f;
    Rigidbody2D _rb = default;
    /// <summary>アイテムをドロップさせるために</summary>
    [SerializeField] GameObject _itemPrefab = default;

    int x = 0;
    int y = 0;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Player")
        {
            CharacterBase characterBase = collision.gameObject.GetComponent<CharacterBase>();
            characterBase.Damage(5);
            AudioManager.Instance.PlaySE(SESoundData.SE.Damage);
            Death();
        }
    }

    private void Death()
    {
        if (_maxHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(_itemPrefab,transform.position, Quaternion.identity);    
    }
}
