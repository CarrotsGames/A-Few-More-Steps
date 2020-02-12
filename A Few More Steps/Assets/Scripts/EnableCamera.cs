﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCamera : MonoBehaviour
{
    public static bool stopTakingPhotos;
    public GameObject photoAlbum;
    public Camera mainCamera;
    [SerializeField]
    private int camToggle;
    // Start is called before the first frame update
    void Start()
    {
        camToggle = 1;
        stopTakingPhotos = false;
        photoAlbum = GameObject.Find("PhotoAlbum");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            camToggle++;
            CameraToggle();

        }
        if (camToggle == 0 && !stopTakingPhotos)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("ScreenShot");
                PhotoCamera.TakeScreenShotStatic(800, 800);
            }

        }
    }
    void CameraToggle()
    {
        if (camToggle > 1)
        {
            //turns on camera
            transform.GetChild(0).gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
            camToggle = 0;
        }
        else
        {
            // turns off camera
            transform.GetChild(0).gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }
    }
}
