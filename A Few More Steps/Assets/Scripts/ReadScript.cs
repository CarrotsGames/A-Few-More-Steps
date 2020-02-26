using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Equips to cameraCM
public class ReadScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        { 
            if (hit.transform.tag == "Book")
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
