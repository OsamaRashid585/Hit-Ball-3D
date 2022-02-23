using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Rigidbody _enemyRb;
    private float _speed = 2;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookdir = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce( lookdir * _speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
