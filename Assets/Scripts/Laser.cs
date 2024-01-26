using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 320F;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int frame = 0;
    
    //  Last frame before suicide.
    [SerializeField]
    private int lifespan = 128;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed* Time.deltaTime);

        if(++frame >= lifespan)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other){
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        ReactiveTarget target = other.GetComponent<ReactiveTarget>();
        
        if(player)
        {
            player.Hit();
        }
        else if(target){
            target.ReactToHit();
            if(transform.parent){
                player = transform.parent.parent.gameObject.GetComponent<PlayerCharacter>();
                if(player){
                    int scor = other.GetComponent<WanderingAI>().Dead? 100 : 10;

                    player.setScore(player.getScore + scor);
                }
            }
        }

        Destroy(this.gameObject);

    }
}
