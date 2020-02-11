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
        
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDir = Camera.main.transform.TransformDirection(moveDir);
        moveDir *= 5;

        movement.controller.Move(moveDir * Time.deltaTime);
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
