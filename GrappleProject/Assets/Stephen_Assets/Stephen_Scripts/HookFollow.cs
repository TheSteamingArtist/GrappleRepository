using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookFollow : MonoBehaviour
{
    public Rigidbody rb;

    public Rigidbody hookAmmoRb;

    public bool hasCollided;

    public bool turnOnLerp;

    public bool grappleWait = true;

    public bool BackwardsArchIdle;

    public float lerpSpeed;

    public float hookForce;

    public GameObject hookAmmo;

    public GameObject Player;

    public GameObject AmmunitionTransform;

    public Animator playerAnim;

    public Animator hookAnim;

    [SerializeField] private GameObject hookObj;

    public Vector3 lookPos;

    private IEnumerator waitTimeCo;

    void Start()
    {

        waitTimeCo = WaitTime(5f);

        hookObj = GameObject.Find("Hook");

        hookAnim = hookObj.GetComponent<Animator>();

        playerAnim = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            hookAmmo.GetComponent<HookedScript>().playerSlide = true;
        }
        
        if(Input.GetKey(KeyCode.E))
        {
            TurnOnE();
            hookAnim.speed = 1;
        }
 
        else if (Input.GetKey(KeyCode.Q))
        {
            TurnOnQ();
            hookAnim.speed = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (grappleWait == true && hookAmmo.transform.parent != null)
            {
                StartCoroutine(waitTimeCo);

                hookAnim.speed = 0;

                hookAmmoRb.isKinematic = false;

                hookAmmoRb.AddForce(transform.up * hookForce);

                hookAmmo.transform.parent = null;

                
            }
            else if(hasCollided == true)
            {
                turnOnLerp = true;
            }
            
            //GameObject hookaim;
            //hookaim=Instantiate(hookAmmo, hookObj.transform.position, hookObj.transform.rotation);
            //hookaim.GetComponent<Rigidbody>().AddForce(transform.up * hookForce);
            //rb.AddForce(transform.up * hookForce);
        }
        if(turnOnLerp == true)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, hookAmmo.transform.position, lerpSpeed);
        }
    }

    public void TurnOnE()
    {
        hookAnim.SetBool("HookAnimBool", true);
    }
    public void TurnOnQ()
    {
        hookAnim.SetBool("HookAnimBool", false);
    }

    public IEnumerator WaitTime(float waitTime)
    {
        waitTime = 10f;
        yield return new WaitForSeconds(waitTime);
        grappleWait = false;
        yield return new WaitForSeconds(waitTime);
        grappleWait = true;
    }
}
