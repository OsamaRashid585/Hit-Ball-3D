using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(destroywait());
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = FindObjectOfType<FollowPlayer>().transform.position - transform.position;
        _rb.AddForce(direction * _moveSpeed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("StrongEnemy"))
        {
            Vector3 away = other.gameObject.transform.position;
            Rigidbody enemyrb = other.gameObject.GetComponent<Rigidbody>();
            enemyrb.AddForce(away * 5f, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
    IEnumerator destroywait()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}