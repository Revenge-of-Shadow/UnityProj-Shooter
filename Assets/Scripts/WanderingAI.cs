using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float normal_speed = 32.0F;
    [SerializeField]
    private float hurt_speed = 16.0F;
    [SerializeField]
    private float speed = 32.0F;    //  Real speed at the moment.
    [SerializeField]
    private float obstacleRange = 48.0F;    //  Keep it bigger that speed to avoid... inconveniences.
    [SerializeField]
    private float HP = 10.0F;
    enum State {alive, hit, dead};
    [SerializeField]
    private State state;
    

    //public State getState{get {return state;}}
    public bool Alive{get {return state==State.alive;}}
    public bool Dead{get {return state==State.dead;}}
    public bool Hurt{get {return state==State.hit;}}
    public float getHP{get {return HP;}}    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Alive || Hurt){
           transform.Translate(0, 0, speed*Time.deltaTime);

           Ray ray = new Ray(transform.position, transform.forward);
           RaycastHit hit;

           if(Physics.SphereCast(ray, 0.75F, out hit) && hit.distance < obstacleRange){
               transform.Rotate(0, Random.Range(110, 110), 0);
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
            this.state = State.hit;
        else
            Die();
    }


    public void setHP(float hp){
        this.HP = hp;
    }
}
