using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookScript : MonoBehaviour
{

    private bool onGround;
    public Vector3 lookPos;
    public GameObject hook;
    public GameObject hookHolder;

    public float travelSpeedHook;
    public float playerTravelSpeed;

    public static bool shot;
    public bool hookedon;
    public GameObject objHooked;

    public float maxDistance;
    private float currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);
        }
        //firing hook

        if(Input.GetMouseButtonDown(0) && shot == false)
        {
            shot = true;

            if (shot == true && hookedon == false)
            {
                hook.transform.Translate(Vector3.forward * Time.deltaTime * travelSpeedHook);
                //Calculates the distance between the current position of this object and the hooks position
                currentDistance = Vector3.Distance(transform.position, hook.transform.position);
                //Repels hook
                if (currentDistance >= maxDistance)
                    ReturnHook();
            }
            
            if (hookedon == true)
            {

                hook.transform.parent = objHooked.transform;
                transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
                float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

                this.GetComponent<Rigidbody>().useGravity = false;

                if (distanceToHook < 1)
                    ReturnHook();
            }
            else
            {
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    void ReturnHook()
    {
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;
        shot = false;
        hookedon = false;
    }
}

