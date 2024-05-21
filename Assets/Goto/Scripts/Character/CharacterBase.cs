using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] protected float _maxHp = 10;

    protected float _currentHp;

    private void Awake()
    {
        _currentHp = _maxHp;
    }

    public void Damage(float damage)
    {
        _currentHp -= damage;
    }
}
