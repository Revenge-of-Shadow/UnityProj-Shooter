using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.2F, 0, Space.Self);
    }
}
