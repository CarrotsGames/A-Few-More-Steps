using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class Swimming : MonoBehaviour
{
    PlayerMovement movement;
    private Vector3 moveDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (movement.isSwimming)
        {
            SwimMovement();
        }
    }
    void SwimMovement()
    {
       if(moveDir.x > 0)
        {
            moveDir.y = 1f;
        }
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDir = Camera.main.transform.TransformDirection(moveDir);  
        if(Input.GetKey(KeyCode.Space))
        {
            moveDir.y += 0.55f;
        }
        moveDir.y -= 0.10f;      
        movement.controller.Move(moveDir * 4 * Time.deltaTime);
 
     }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log("swimming");
            movement.isSwimming = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log("ExitWater");
            movement.isSwimming = false;
     
        }
    }
}
