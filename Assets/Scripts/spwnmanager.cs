using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwnmanager : MonoBehaviour
{
   [SerializeField] private GameObject Enemypre;
   [SerializeField] private GameObject Powerpre;
    private int _enemycount;
    private int _wavenum = 1;
    // Start is called before the first frame update
    void Start()
    {
        spwnenemy(_wavenum);
        Instantiate(Powerpre, new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9)), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemycount = FindObjectsOfType<FollowPlayer>().Length;
        if(_enemycount == 0)
        {
            _wavenum++;
            spwnenemy(_wavenum);
            Instantiate(Powerpre, new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9)), Quaternion.identity);
        }
    }

    void spwnenemy(int snum)
    {
        for(int i = 0; i < snum; i++)
        {
            Instantiate(Enemypre, new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9)), Quaternion.identity);
        }
    }
}
