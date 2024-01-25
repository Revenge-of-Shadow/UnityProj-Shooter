using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        PlayerCharacter p = other.GetComponent<PlayerCharacter>();
        if(p && p.getHP < PlayerCharacter.maxHP){
            p.setHP(PlayerCharacter.maxHP);
            p.Live();
        }else {
            WanderingAI w = other.GetComponent<WanderingAI>();
            if(w && w.getHP < WanderingAI.maxHP){
                w.setHP(WanderingAI.maxHP);
                w.Live();
            }
            else
                return;
        }
        
        Destroy(this.gameObject);
    }
}
