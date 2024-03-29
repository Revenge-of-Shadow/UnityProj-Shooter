using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit(){
        WanderingAI behaviour = GetComponent<WanderingAI>();

        if(behaviour != null){
            if(behaviour.Alive){
                behaviour.Hit();
            }
            if(behaviour.Dead)
                StartCoroutine(Die());
        }

    }

    private IEnumerator Die(){
        
        yield return new WaitForSeconds(1.5F);
        Destroy(this.gameObject);
    }
}
