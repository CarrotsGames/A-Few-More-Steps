using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingToss : MonoBehaviour
{
    int index = 0;
    [SerializeField]
    private float force;
    public GameObject[] rings;
    public Camera camera;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            force += 0.25f;
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 planeNormal = -camera.transform.forward;
            mousePos = Vector3.ProjectOnPlane(mousePos, planeNormal);
            Vector3 pos = Vector3.ProjectOnPlane(transform.position, planeNormal);
            Vector3 dir = (mousePos - pos).normalized;
            rings[index].transform.position = camera.transform.position;
            rings[index].SetActive(true);
            rings[index].GetComponent<Rigidbody>().AddForce(dir);
            force = 0;
        }
    }
}
