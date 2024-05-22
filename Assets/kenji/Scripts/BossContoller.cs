using UnityEngine;

public class BossContoller : ItemBase
{
    // オブジェクト・コンポーネント
    protected Rigidbody2D rigidbody2D; // RigidBody2D
    protected SpriteRenderer spriteRenderer;// 敵スプライト
    protected Transform actorTransform; // 主人公(アクター)のTransform

    // 画像素材
    public Sprite sprite_Defeat; // 被撃破時スプライト(あれば)

    // 各種変数
    // 基礎データ(インスペクタから入力)
    [Header("最大体力(初期体力)")]
    public int maxHP;
    [Header("接触時アクターへのダメージ")]
    public int touchDamage;
    [Header("ボス敵フラグ(ONでボス敵として扱う。１ステージに１体のみ)")]
    public bool isBoss;
    [Header("ボス用被撃破パーティクルPrefab")]
    public GameObject bossDefeatParticlePrefab;
    // その他データ
    [HideInInspector] public int nowHP; // 残りHP
    [HideInInspector] public bool isVanishing; // 消滅中フラグ trueで消滅中である
    [HideInInspector] public bool isInvis; // 無敵モード
    [HideInInspector] public bool rightFacing; // 右向きフラグ(falseで左向き)


}
