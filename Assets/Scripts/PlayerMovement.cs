using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private CharacterController controller;
   [SerializeField] float speed = 10;
   Vector3 velocity;
   float jumpHeight = 3f;
   float gravity = -9.81f;
   bool isGrounded;
   public Transform groundCheck;
   float distance = 0.5f;
   public LayerMask groundLayer;
   private void Update() 
   {
      
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        if(isGrounded) 
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        else 
        {
            controller.Move(move * 2 * Time.deltaTime);
        }
           

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
      
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, distance, groundLayer);

   }
   
}
