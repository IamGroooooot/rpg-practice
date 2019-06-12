using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JHPlayerMoter))]
public class JHPlayerCtrl : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
    JHPlayerMoter motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<JHPlayerMoter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100,movementMask))
            {
                Debug.Log("We hit "+ hit.collider.name+ " "+ hit.point);
                //Move  player to where we hit
                motor.MoveToPoint(hit.point);
                // Stop Foucusing obj
            }
        }
    }
}
