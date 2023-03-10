using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
 
    public enum State { patrol ,  rest }
    public State state;
    void Start()
    {

    }

    void Update()
    {
        switch (state)
        {
            case State.patrol:
                break;

            case State.rest:
                break;

         
        }
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            state = State.patrol;
           yield return new WaitForSeconds(Random.Range(1,16));
            state = State.rest;
            yield return new WaitForSeconds(5);
        }
        
    }
    void PatrolandAttacking()
    {
       
        //pendant to create void 
    }
    void rest()
    {
        
        //pendant to create void 
    }
   
}
