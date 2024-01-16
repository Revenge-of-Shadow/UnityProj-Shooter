using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWalk : MonoBehaviour
{
    public float _distance = 160.0F;
    public int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(++frame >= 301) frame=0;
        
        else if(frame > 0 && frame <= 50)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _distance/100.0F);
        }
        else if(frame > 50 && frame <= 100)
        {
            transform.Rotate(0, 180/50.0F, 0, Space.Self);
        }
        else if(frame > 100 && frame <= 200)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _distance/100.0F);
        }
        else if(frame > 200 && frame <= 250)
        {
            transform.Rotate(0, 180/50, 0, Space.Self);
        }
        else if(frame > 250 && frame <= 300)
        {    
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _distance/100.0F);
        }
        
    }
}
