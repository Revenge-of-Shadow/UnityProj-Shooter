using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/** https://learn.microsoft.com/en-ca/dotnet/api/system.enum.hasflag?view=net-8.0 **/


public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float normal_speed = 16.0F;
    [SerializeField]
    private float hurt_speed = 8.0F;
    [SerializeField]
    private float speed = 16.0F;    //  Real speed at the moment.
    [SerializeField]
    private float obstacleRange = 48.0F;    //  Keep it bigger than speed to avoid... inconveniences.
    [SerializeField]
    private float HP = 10.0F;

    [SerializeField]
    private int frame = 0;


    [System.Flags]
    public enum State {dead = 0, alive = 1, hit = 2, searching = 4};
    [SerializeField]
    private State state;
    
    [SerializeField]
    private GameObject fireballPrefab;

    private GameObject _fireball;


    public bool Alive{get {return state.HasFlag(State.alive);}}
    public bool Dead{get {return state.Equals(State.dead);}}
    public bool Hurt{get {return state.HasFlag(State.hit);}}
    public bool Searching{get {return state.HasFlag(State.searching);}}
    public float getHP{get {return HP;}}    

    void Start()
    {
        Live();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Dead){
            
            if(Searching){
                if(++frame >= 360){
                    frame = 0;
                    StopSearch();
                }

                Search();
            }else{
                transform.Translate(0, 0, speed*Time.deltaTime);

                if(++frame >= 100){
                    frame = 0;
                    StartSearch();
                }
            }
        }
    }

    public void Die(){
        this.state = State.dead;
        this.transform.Rotate(-90, 0, 0);
        this.transform.position = new Vector3(
            transform.position.x, 
            transform.position.y - transform.localScale.y/2.0F,
            transform.position.z);
    }
    public void Live(){
        this.state = State.alive;
        speed = normal_speed;
    }
    public void Hit(){
        setHP(getHP-1);
        speed = hurt_speed;

        if(getHP>0)
            this.state |= State.hit;
        else
            Die();
    }


    public void setHP(float hp){
        this.HP = hp;
    }

    public void StartSearch(){
        this.state |= State.searching;
    }
    public void StopSearch(){
        this.state = state & ~State.searching;
    }
    public void Search(){
        if(CastRay())
            StopSearch();
        else
            transform.Rotate(0, 1, 0);
    }


    public bool CastRay(){
            bool result = false;

           Ray ray = new Ray(transform.position, transform.forward);
           RaycastHit hit;

           if(Physics.SphereCast(ray, 0.75F, out hit))
            {
                GameObject hitobject = hit.transform.gameObject;

                if(hitobject.GetComponent<PlayerCharacter>()){
                    if(_fireball == null){
                        _fireball = Instantiate(fireballPrefab);
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5F);
                        _fireball.transform.rotation = transform.rotation;
                        result = true;
                    }
                }
                else if(hitobject.GetComponent<Laser>())
                {
                    //  Ignore. But anyway
                    result = true;
                }

                else if(hit.distance < obstacleRange)
                {
                   transform.Rotate(0, UnityEngine.Random.Range(110, 110), 0);
                }
            }

            return result;
        }
}
