using UnityEngine;
using UnityEngine.UI;

public class BackGroundController : MonoBehaviour
{

    private const float MAX_OFFSET = 1f;
    private const string PROPERTY_NAME = "_MainTex";

    [SerializeField] private Vector2 _offsetSpeed;

    Material _material;
    GameObject _player;
    Rigidbody2D _playerRigidbody;

    void Start()
    {
        if (TryGetComponent(out Image image))
        {
            _material = image.material;
        }
        _player = GameObject.FindWithTag("Player");
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_material != null)
        {
            // �}�e���A���̃e�N�X�`����Offset�𓮂����ē����Ă���悤�Ɍ�����
            var x = Mathf.Repeat(Time.deltaTime * _offsetSpeed.x * _playerRigidbody.velocity.x, MAX_OFFSET);
            var y = Mathf.Repeat(Time.deltaTime * _offsetSpeed.y * _playerRigidbody.velocity.y, MAX_OFFSET);
            var offset = _material.GetTextureOffset(PROPERTY_NAME);
            offset += new Vector2(x, y);
            _material.SetTextureOffset(PROPERTY_NAME, offset);
        }
    }

    private void OnDestroy()
    {
        // �I�u�W�F�N�g���j�������^�C�~���O�Ɉʒu�����Z�b�g����
        if (_material != null)
        {
            _material.SetTextureOffset(PROPERTY_NAME, Vector2.zero);
        }
    }
}
