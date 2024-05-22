using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSe : MonoBehaviour
{
    [SerializeField] AudioSource _deadse;
    // Start is called before the first frame update
    PlayerController _playercontr = new PlayerController();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( _playercontr.IsDead == true )
        {
            _deadse.Play();
        }
    }
}
