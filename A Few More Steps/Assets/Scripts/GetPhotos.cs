using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetPhotos : MonoBehaviour
{
    private GameObject mainCam;
    private GameObject photoCam;
    private bool nullPhoto;
    int toggle;
     List<Texture2D> photos;
    private void Start()
    {
        mainCam = GameObject.Find("CMMainCamera");
        photoCam = GameObject.Find("PhotoCam");
        photos = new List<Texture2D>();
        toggle = 0;
        // turn off galery
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !PlayerMovement.isSwimming)
        {
            toggle++;
            TogglePics();
        }
       
    }
    void TogglePics()
    {
        if (toggle > 1)
        {
            if (!EnableCamera.cameraOn)
            {
                PlayerMovement.stopMovement = false;
            }
            EnableCamera.stopTakingPhotos = false;
            // turn off galery
            transform.GetChild(0).gameObject.SetActive(false);
            toggle = 0;
            Cursor.lockState = CursorLockMode.Locked;
            photoCam.transform.GetChild(0).GetComponent<MouseLook>().enabled = true;
            mainCam.GetComponent<MouseLook>().enabled = true;
        }
        else
        {
         
            PlayerMovement.stopMovement = true;
         
            // stops camera from taking photos
            EnableCamera.stopTakingPhotos = true;
            // turn on gallery
            transform.GetChild(0).gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            photoCam.transform.GetChild(0).GetComponent<MouseLook>().enabled = false;
            mainCam.GetComponent<MouseLook>().enabled = false;

        }
    }
    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {
     
        Sprite newSprite;
        // loads new texture made from camera
        Texture2D a = LoadTexture(FilePath);
        CheckForPhoto();
        // creates sprite of texture
        newSprite = Sprite.Create(a, new Rect(0, 0, 800, 800), new Vector2(0, 0), 1);
        GameObject gallery = transform.GetChild(0).gameObject;
        if (nullPhoto)
        {
            nullPhoto = false;    
            return null;
        }
        // adds it to the sprite image
        gallery.transform.GetChild(PhotoCamera.photoIndex).GetComponent<Image>().sprite = newSprite;
         Color alpha = gallery.transform.GetChild(PhotoCamera.photoIndex).GetComponent<Image>().color;
         alpha.a = 1f;
         gallery.transform.GetChild(PhotoCamera.photoIndex).GetComponent<Image>().color = alpha;
      
        return newSprite;

    }
    void CheckForPhoto()
    {
        GameObject gallery = transform.GetChild(0).gameObject;
            
        for (int i = 0; i < gallery.transform.childCount; i++)
        {
            // checks for an open slot to put the photo in
            // to avoid overrighting a photo if one is deleted
            if(gallery.transform.GetChild(i).tag != "Photo")
            {
                Debug.Log("forLoop");
                PhotoCamera.photoIndex = i;
                gallery.transform.GetChild(i).tag = "Photo";
                return;
            }
        }


    }
    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (System.IO.File.Exists(FilePath))
        {
            // Reads in finished png file
            FileData = System.IO.File.ReadAllBytes(FilePath);
            // creates empty texture to write png to
            Tex2D = new Texture2D(2, 2);          
            // Load the imagedata into the texture (size is set automatically)
            if (Tex2D.LoadImage(FileData))          
                return Tex2D;                
        }
        nullPhoto = true;
        return null;                     
    }


}
