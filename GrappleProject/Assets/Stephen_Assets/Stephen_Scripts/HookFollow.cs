using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookFollow : MonoBehaviour
{

    public Animator hookAnim;
    [SerializeField] private GameObject hookObj;
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
            hookAnim.SetBool("HookAnimBool", true);
            
        }
 
        else if (Input.GetKey(KeyCode.Q))
        {
            
            hookAnim.SetBool("HookAnimBool", false);
       
            
        }
        else if(Input.GetKey(KeyCode.Mouse0))
        {
            hookAnim.SetBool("Stop", true);
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
