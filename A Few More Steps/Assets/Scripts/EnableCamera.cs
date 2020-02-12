using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCamera : MonoBehaviour
{
    public static bool cameraOn;
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
        if(Input.GetKeyDown(KeyCode.F) && !stopTakingPhotos)
        {
            camToggle++;
            CameraToggle();

        }
        // take photos
        if (PhotoCamera.photoIndex < 8 && camToggle == 0 && !stopTakingPhotos)
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
            transform.GetChild(0).gameObject.transform.position = mainCamera.transform.position;
 

            mainCamera.gameObject.SetActive(false);
            camToggle = 0;
            PlayerMovement.stopMovement = true;
            cameraOn = true;
        }
        else
        {
            // turns off camera
            transform.GetChild(0).gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            PlayerMovement.stopMovement = false;
            cameraOn = false;

        }
    }
}
