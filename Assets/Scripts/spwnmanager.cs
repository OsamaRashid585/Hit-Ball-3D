using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnmanager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPre;
    [SerializeField] private GameObject _strongEnemyPre;
    [SerializeField] private GameObject _powerPre;
    [SerializeField] private GameObject _projectilePowerPre;
    [SerializeField] private GameObject _smashAttackPowerup;
    [SerializeField] private GameObject _pojectilePre;
    [SerializeField] private GameObject _bossEnemyPre;
    private int _enemycount;
    private int _wavenum = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", 1, 0.7f);
        spwnenemy(_wavenum);
        InvokeRepeating("SpawnStrongEnemy",10,15);
        Instantiate(_powerPre, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        _enemycount = FindObjectsOfType<FollowPlayer>().Length;
        if(_enemycount == 0)
        {
            _wavenum++;
            spwnenemy(_wavenum);
            Instantiate(_powerPre, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);
            Instantiate(_projectilePowerPre, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);
            Instantiate(_smashAttackPowerup, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);
        }

        if(_wavenum == 10)
        {
            Instantiate(_bossEnemyPre, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);
        }
    }

    void spwnenemy(int snum)
    {
        for(int i = 0; i < snum; i++)
        {
            Instantiate(_enemyPre, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);
        }
    }

    private void SpawnStrongEnemy()
    {
        Instantiate(_strongEnemyPre, new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)), Quaternion.identity);
    }
    private void SpawnProjectile()
    {
        if (FindObjectOfType<Player>().IsFiringPowerUP == true)
        {
            var pos = GameObject.Find("Player").transform.position;
            Instantiate(_pojectilePre,pos,Quaternion.Euler(90f,0f,0f));
        }
    }
}
