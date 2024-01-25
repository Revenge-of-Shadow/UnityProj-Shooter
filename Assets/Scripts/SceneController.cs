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
    [SerializeField]
    private GameObject _boxPrefab;
    private System.Random _rnd = new System.Random();

    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField]
    private GameObject _box;
    [SerializeField]
    private int randRange = 500;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; ++i){
            targets.Add(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < targets.Count; ++i){
            if(targets[i]==null){
                targets[i] = Instantiate(_targetPrefab) as GameObject;
                targets[i].transform.position = new Vector3(_rnd.Next(-randRange, randRange), 80, _rnd.Next(-randRange, randRange));
                //targets[i].transform.position = new Vector3(0, 70, 0);
            }
        }

        if(_box == null){
            _box = Instantiate(_boxPrefab) as GameObject;
            _box.transform.position = new Vector3(_rnd.Next(-randRange, randRange), 1024, _rnd.Next(-randRange, randRange));
        }
    }
}
