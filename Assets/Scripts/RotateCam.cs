using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    private float _speed = 70f;
    private float _hori_Inp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _hori_Inp = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, _speed * Time.deltaTime * _hori_Inp);
    }
}
