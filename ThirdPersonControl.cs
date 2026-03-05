using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonControl : MonoBehaviour
{
    public Transform cam;  // Camera's transform
    public CharacterController controller;  // CharacterController component
    public float speed = 6.0f;  // Movement speed
    public float turnSmoothTime = 0.1f;  // Turn smoothing time
    float turnSmoothVelocity;  // Internal variable for turn smooth velocity

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 direction = new Vector3(Horizontal, 0, Vertical).normalized;  // Calculate movement direction

        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on input and camera rotation
            float targetAngle = (Mathf.Atan2(direction.x, direction.z)) * Mathf.Rad2Deg + cam.eulerAngles.y;
            
            // Smoothly interpolate the current player rotation angle towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothTime, turnSmoothVelocity);
            
            // Calculate the movement direction based on the target angle
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Rotate the player smoothly towards the calculated angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f);  

            // Move the player in the calculated direction using CharacterController
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //Debug.Log("Player is moving in direction: " + moveDir.normalized);
        }
    }
}

