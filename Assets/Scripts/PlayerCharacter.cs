using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    public const float maxHP = 10.0F;
    [SerializeField]
    private float HP = 10.0F;
    [SerializeField]
    private int score = 0;
    [System.Flags]
    public enum State {dead = 0, alive = 1, hit = 2, searching = 4};
    [SerializeField]
    private State state;


    public bool Alive{get {return state==State.alive;}}
    public bool Dead{get {return state==State.dead;}}
    public bool Hurt{get {return state==State.hit;}}
    public float getHP{get {return HP;}}
    public int getScore{get {return score;}}

    public static global::System.Single MaxHP => maxHP;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Dead){
            Live();
        }
    }



    public void Die(){
        Debug.Log("I die.");
        this.transform.position = new Vector3(0, 512, 0);
        this.HP = maxHP;
        this.score = 0;
        this.state = State.dead;
    }
    public void Live(){
        Debug.Log("I live.");

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
    public void setScore(int score){
        this.score = score;
    }
}
