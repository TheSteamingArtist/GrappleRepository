﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRigidBodyScript : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hookable")
        {
            player.GetComponent<GrapplingHookScript>().hookedon = true;
        }
    }
}
