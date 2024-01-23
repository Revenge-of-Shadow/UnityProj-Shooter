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
    private System.Random _rnd = new System.Random();

    [SerializeField]
    private List<GameObject> targets = new List<GameObject>();
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
                targets[i].transform.position = new Vector3(_rnd.Next(-100, 100), 70, _rnd.Next(-256, 256));
                //targets[i].transform.position = new Vector3(0, 70, 0);
            }
        }
    }
}
