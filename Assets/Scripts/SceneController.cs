using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Random;
public class SceneControlelr : MonoBehaviour
{
    //  Makes the variable visible in Unity!
    [SerializeField]
    private GameObject _targetPrefab;
    private GameObject _target;
    private System.Random _rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_target==null){
            _target = Instantiate(_targetPrefab) as GameObject;
            //_target.transform.position = new Vector3(_rnd.Next(-256, 256), 70, _rnd.Next(-256, 256));
            _target.transform.position = new Vector3(0, 70, 0);
        }
    }
}
