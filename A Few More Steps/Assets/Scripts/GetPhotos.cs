using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetPhotos : MonoBehaviour
{
     List<Texture2D> photos;
    int photoNum;
    private void Start()
    {
        photos = new List<Texture2D>();

    }
    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {
    
        Sprite newSprite;
        // loads new texture made from camera
        Texture2D a = LoadTexture(FilePath);
        // creates sprite of texture
        newSprite = Sprite.Create(a, new Rect(0, 0, 800, 800), new Vector2(0, 0), 1);
        // adds it to the sprite image
        transform.GetChild(0).GetComponent<Image>().sprite = newSprite;
        return newSprite;

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
        return null;                     
    }


}
