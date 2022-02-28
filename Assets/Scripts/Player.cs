using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float _movSpeed = 7;
    private Rigidbody _playerRb;
    private float _verInp;

    private GameObject _foklPoint;
    private bool ispickup;

    public bool IsSmashAttackPowerup;
    public bool IsFiringPowerUP;
   [SerializeField] private GameObject Powerfield;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _foklPoint = GameObject.Find("FoklPoint");
        IsFiringPowerUP = false;
        IsFiringPowerUP = false;

    }

    // Update is called once per frame
    void Update()
    {
        _verInp = Input.GetAxis("Vertical");
        _playerRb.AddForce((_foklPoint.transform.forward).normalized * _movSpeed  * _verInp);
        Powerfield.transform.position = transform.position + new Vector3(0, -0.2f, 0);
        if (Input.GetKeyDown(KeyCode.Space) && IsSmashAttackPowerup == true)
        {
            _playerRb.AddForce(Vector3.up * 50, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space) && IsSmashAttackPowerup == true)
        {
            Debug.Log("yeh");
            _playerRb.AddForce(Vector3.down * 100, ForceMode.Impulse);
            StartCoroutine(WaitForSmash());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerup"))
        {
            Destroy(other.gameObject);
            ispickup = true;
            Powerfield.gameObject.SetActive(true);
            StartCoroutine(WatForPowerup());
        }
        
        if (other.gameObject.CompareTag("FiringPowerUP"))
        {
            IsFiringPowerUP = true;
            Destroy(other.gameObject);
            Powerfield.gameObject.SetActive(true);
            StartCoroutine(WatForPowerup());
        }
        if (other.gameObject.CompareTag("SmashAttackPowerup"))
        {
            IsSmashAttackPowerup = true;
            Destroy(other.gameObject);
            Powerfield.gameObject.SetActive(true);
            StartCoroutine(WatForPowerup());
        }
    }
    IEnumerator WatForPowerup()
    {
        yield return new WaitForSeconds(7);
        ispickup = false;
        IsSmashAttackPowerup = false;
        IsFiringPowerUP = false;
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

        if (collision.gameObject.CompareTag("BossEnemy"))
        {
            transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f) ;
            Debug.Log("kadk");
        }

        if (collision.gameObject.CompareTag("StrongEnemy"))
        {
            Vector3 away = transform.position - collision.gameObject.transform.position;

            _playerRb.AddForce(away * 15f, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("end"))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator WaitForSmash()
    {
        yield return new WaitForSeconds(0.2f);
        var mypos = transform.position;
        var enemys = GameObject.FindGameObjectsWithTag("enemy");
        foreach(var allenemys in enemys)
        {
            allenemys.GetComponent<Rigidbody>().AddForce((allenemys.transform.position - transform.position) * 10, ForceMode.Impulse);
        }
        var StrongEnemy = GameObject.FindGameObjectsWithTag("StrongEnemy");
        foreach (var allstrongenemys in StrongEnemy)
        {
            allstrongenemys.GetComponent<Rigidbody>().AddForce((allstrongenemys.transform.position - transform.position) * 10, ForceMode.Impulse);
        }
    }
}
