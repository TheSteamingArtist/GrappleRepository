using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookReturnScript : MonoBehaviour
{
    public GameObject hookobj;

    public Rigidbody hookammoRb;

    float dist;

    public GameObject player;

    public GameObject ammoTransobj;

    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, hookobj.transform.position);

        if(dist >= 18)
        {
            hookobj.transform.position = ammoTransobj.transform.position;
            hookobj.transform.parent = ammoTransobj.transform;
            hookammoRb.isKinematic = true;

        }



    }

    
}
