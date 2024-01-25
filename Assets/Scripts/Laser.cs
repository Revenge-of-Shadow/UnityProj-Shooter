using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 160F;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int frame = 0;
    
    //  Last frame before suicide.
    [SerializeField]
    private int lifespan = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed* Time.deltaTime);

        if(++frame == 512)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other){
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player)
        {
            player.Hit();
        }
        else if(!other.GetComponent<WanderingAI>())
            Destroy(this.gameObject);
    }
}
