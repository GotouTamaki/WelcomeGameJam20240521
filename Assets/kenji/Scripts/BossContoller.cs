using UnityEngine;

public class BossContoller :CharacterBase

{
    // 画像素材
    [SerializeField] Sprite _beamAt;

    [SerializeField]
    private Animation animation = default(Animation);
    private Rigidbody2D _rigidbody2D = default(Rigidbody2D);


    // 各種変数
    // 基礎データ(インスペクタから入力)
    GameObject _player = default;
    [Header("ボス敵フラグ(ONでボス敵として扱う。１ステージに１体のみ)")]
    public bool isBoss;
    [Header("ボス用被撃破パーティクルPrefab")]
    public GameObject bossDefeatParticlePrefab;
    // その他データ
    [HideInInspector] public bool isInvis; // 無敵モード
    private Vector2 _bulletMovePower;
    int x = 0;
    int y = 0;


    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }
    public void FixedUpdate()
    {
        if (_player)
        {
            Vector2 dir = _player.transform.position - this.transform.position;

        }
    }
}
