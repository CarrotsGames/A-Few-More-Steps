using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public float distance;
    public LayerMask mask;
    private GameObject inventory;
    private void Start()
    {
        inventory = GameObject.Find("Inventory");
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit, distance, mask) && !PlayerMovement.stopMovement)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.GetComponent<Inventory>().inventory(hit.transform.gameObject.name);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
