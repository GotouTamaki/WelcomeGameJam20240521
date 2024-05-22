using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _BylletPrefab;
    [SerializeField] private Transform _muzzleTransform;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_BylletPrefab, _muzzleTransform.position, _muzzleTransform.rotation);
        }
    }
}
