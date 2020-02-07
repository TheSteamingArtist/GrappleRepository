using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookFollow : MonoBehaviour
{

    public Animator hookAnim;
    [SerializeField] private GameObject hookObj;
    public bool BackwardArch;
    public bool BackwardsArchIdle;
    public Vector3 lookPos;
    // Start is called before the first frame update
    void Start()
    {
        hookObj = GameObject.Find("Hook");

        hookAnim = hookObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            BackwardArch = true;
            //Create Coroutine wait 0.5 seconds and then play idle animation for motion
        }
        
        if (BackwardArch == false)
        {
            hookAnim.SetBool("HookAnimBool", false);
        }
        
        if (BackwardArch == true)
        {
            hookAnim.SetBool("HookAnimBool", true);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //Stop Coroutine
            BackwardArch = false;

            if(BackwardArch == false)
            {
                hookAnim.SetBool("BacktoIdle", true);
            }
            
        }
        
    }

    void HandleAimingPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 lookP = hit.point;
            lookP.z = transform.position.z;
            lookPos = lookP;
        }
    }

    void HandleRotation()
    {
        Vector3 directionToLook = lookPos - transform.position;
        directionToLook.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook);


        Debug.Log(lookPos.x + " " + transform.position.x);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15);
    }

    public void TurnOnE()
    {
        hookAnim.SetBool("HookAnimBool", true);
    }
    public void TurnOnQ()
    {
        hookAnim.SetBool("HookAnimBool", false);
    }
    public void BackToIdle()
    {
        hookAnim.SetBool("BacktoIdle", true);
    }
    public void TurnOffQ()
    {
        hookAnim.SetBool("PressQ", false);
    }
}
