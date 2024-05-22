using UnityEditor;
using UnityEngine;

public class BossContoller :CharacterBase

{
    // 画像素材
    [SerializeField] Sprite _beamAt;

    [SerializeField]
    private Animation animation = default(Animation);
    private AnimatorStateInfo stateInfo;

    // 各種変数
    // 基礎データ(インスペクタから入力)
    [Header("ボス敵フラグ(ONでボス敵として扱う。１ステージに１体のみ)")]
    public bool isBoss;
    [Header("ボス用被撃破パーティクルPrefab")]
    public GameObject bossDefeatParticlePrefab;
    // その他データ
    [HideInInspector] public bool isInvis; // 無敵モード

    public void Update()
    {
        if (animation.tag == "Boss BeamAttack")
        {
            Instantiate(_beamAt,transform.position, Quaternion.identity);
        }
    }
}
