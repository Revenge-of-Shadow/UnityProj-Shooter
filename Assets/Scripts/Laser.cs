using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 160F;
    [SerializeField]
    private int damage = 1;
    // Start is called before 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed* Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player)
        {
            player.Hit();
        }
        Destroy(this.gameObject);
    }
}
