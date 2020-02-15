using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookedScript : MonoBehaviour
{
    public Rigidbody hookrb;

    public GameObject hookObj;

    private IEnumerator playerCoroutine;

    public Rigidbody playerRb;

    public GameObject AmmoTrans;

    public bool playerSlide;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            playerRb.isKinematic = false;
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hookObj.GetComponent<HookFollow>().turnOnLerp=false;

            this.gameObject.transform.position = AmmoTrans.gameObject.transform.position;

            this.gameObject.transform.parent = AmmoTrans.gameObject.transform;
            hookObj.GetComponent<HookFollow>().hasCollided = false;
            if (hookObj.GetComponent<HookFollow>().turnOnLerp == false)
            {
                playerRb.isKinematic = true;
                
            }
        }  
        if (collision.gameObject.tag == "Hookable")
        {
            hookObj.GetComponent<HookFollow>().hasCollided = true;
            hookrb.isKinematic = true;
        }
    }
}
