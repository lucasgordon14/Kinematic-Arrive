using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrive : MonoBehaviour
{
    internal object gameobject;
    [SerializeField] private Transform trans;
    // Initializes  Player Transform
    [SerializeField] private Rigidbody rb;
    // Initializes  Player Rigidbody
    [SerializeField] private Transform target;
    // Initializes Target Transform

   


    public float maxSpeed;
    private float radiusOfSatisfaction;

    // Start is called before the first frame update
    void Start()
    {
        //maxSpeed = 5f;
        // Sets the max speed on start

        //radiusOfSatisfaction = 2f;
        maxSpeed = 0f;
        // Sets the max speed on start

        radiusOfSatisfaction = 2f;

        Vector3 mouse = Input.mousePosition;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            maxSpeed = 5f;
            // Sets the max speed on start

            radiusOfSatisfaction = 2f;

            Vector3 mouse = Input.mousePosition;


            Vector3 clickPosition = -Vector3.one;
            // Sets a default position that is noticable if an error were to occur.

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Uses the main camera to send a ray (a line) down to the vector that is created upon the mouse click (left button on mouse).
            RaycastHit hit;
            // The "hit" component of the ray

            if(Physics.Raycast(ray, out hit))
            {
                // If the raycast detects a "hit" i.e. a click
                clickPosition = hit.point;
                // set the click position equal to the location of the hit point (written as a vector3). 
            }

            target.position = clickPosition;
            // Set the object we are trying to reach, the target;  To where we click.  
            Debug.Log(clickPosition);
            // Outputs the vector3 of where the mouse was clicked for debug purposes.  

         
        }

        // RETYPE

        // Calculate vector from character to target
        Vector3 towards = target.position - trans.position;
        trans.rotation = Quaternion.LookRotation(towards);

        // If we haven't reached the target yet
        if (towards.magnitude > radiusOfSatisfaction)
        {

            // Normalize vector to get just the direction
            towards.Normalize();
            towards *= maxSpeed;

            // Move character
            rb.velocity = towards;
        }

       
    }
 
}
