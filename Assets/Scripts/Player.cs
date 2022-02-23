using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float _movSpeed = 6;
    private Rigidbody _playerRb;
    private float _verInp;

    private GameObject _foklPoint;
    private bool ispickup;
   [SerializeField] private GameObject Powerfield;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _foklPoint = GameObject.Find("FoklPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        _verInp = Input.GetAxis("Vertical");
        _playerRb.AddForce((_foklPoint.transform.forward).normalized * _movSpeed  * _verInp);
        Powerfield.transform.position = transform.position + new Vector3(0, -0.2f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerup"))
        {
            Destroy(other.gameObject);
            ispickup = true;
            Powerfield.gameObject.SetActive(true);
            StartCoroutine(watforpowerup());
        }
    }
    IEnumerator watforpowerup()
    {
        yield return new WaitForSeconds(7);
        ispickup = false;
        Powerfield.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && ispickup)
        {
            Rigidbody enemyrb =  collision.gameObject.GetComponent<Rigidbody>();

            Vector3 away = collision.gameObject.transform.position - transform.position;

            enemyrb.AddForce(away * 15f, ForceMode.Impulse);
        }
    }
}
