using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject _player = default;    //プレイヤー
    //plaerの攻撃を引っ張る
    /// <summary>この範囲にプレイヤーがいる場合、プレイヤーを見つけることができる</summary>
    [SerializeField] float m_playerSearchRangeRadius = 5f;
    /// <summary>生成する敵のプレハブ</summary>
    [SerializeField] GameObject _enemyPrefab = default;
    /// <summary>敵を生成する場所</summary>
    [SerializeField] Transform[] _spawnPoints = default;
    /// <summary>動く速さ</summary>
    [SerializeField] float _speed = 2f;
    private int _eHP;
    Rigidbody2D _rb = default;

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
        if (gameObject.tag == "Enemy")
        {
            // 敵のHPをプレイヤーのatk分、減少させる
            //_eHP -= _player;//

            if (_eHP == 0)
            {

                // オブジェクトを破壊する
                Destroy(transform.root.gameObject);

            }
        }
    }

}
