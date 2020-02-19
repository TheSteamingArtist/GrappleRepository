using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCooldown : MonoBehaviour
{
    public bool OnRandom;

    public float randomNumber;


    public int RandomInt;

    
    public float coolDown;

    void Start()
    {
        RandomInt = Random.Range(1, 5) * 2;

        randomNumber = (float)RandomInt / 10;

        OnRandom = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        coolDown = randomNumber -= Time.deltaTime;

        
        if (OnRandom == true)
        {
            if(randomNumber%2==0)
            {
               
            }

            
            
            if(randomNumber <= 4)
            {

            }

            if(randomNumber <= 6)
            {

            }

            if(randomNumber <= 8)
            {

            }

           
            if(randomNumber%2==0)
            {
                randomNumber -= Time.deltaTime;
            }
            else
            {
                
            }
        }
    }
}
