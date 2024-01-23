using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private float HP = 10.0F;
    [System.Flags]
    public enum State {dead = 0, alive = 1, hit = 2, searching = 4};
    [SerializeField]
    private State state;


    public bool Alive{get {return state==State.alive;}}
    public bool Dead{get {return state==State.dead;}}
    public bool Hurt{get {return state==State.hit;}}
    public float getHP{get {return HP;}}    

    // Start is called before the first frame update
    void Start()
    {
        Live();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Die(){
        this.state = State.dead;
    }
    public void Live(){
        this.state = State.alive;
    }
    public void Hit(){
        setHP(getHP-1);

        if(getHP>0)
            this.state |= State.hit;
        else
            Die();
    }


    public void setHP(float hp){
        this.HP = hp;
    }
}
