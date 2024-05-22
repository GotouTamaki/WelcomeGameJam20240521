using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BubbleBulletController : MonoBehaviour
{
    [SerializeField] private float _bulletMovePower = 1f;
    [SerializeField] private float _bulletAttack = 1f;
    [SerializeField] private float _lifeTime = 20f;
    [SerializeField] private int _boundCountLimit = 5;

    private Rigidbody2D _rigidbody2D;
    private int _boundCount;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        PlayerController player = FindAnyObjectByType<PlayerController>();
        _rigidbody2D.AddForce(player.LookingRight ? Vector2.right * _bulletMovePower : Vector2.left * _bulletMovePower,
            ForceMode2D.Impulse);
    }

    private void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0 || _boundCount > _boundCountLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CharacterBase characterBase = GetComponent<CharacterBase>();
            characterBase.Damage(_bulletAttack);
            Destroy(this.gameObject);
        }

        _boundCount++;
    }
}