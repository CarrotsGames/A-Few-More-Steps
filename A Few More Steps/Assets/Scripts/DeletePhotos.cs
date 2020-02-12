using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeletePhotos : MonoBehaviour
{
   public void DeletePhoto()
    {
        PhotoCamera.photoIndex -= 1;
        // CLEAR IMAGE (Turn down alpha) 
        Color alpha = GetComponent<Image>().color;
        alpha.a = 0f;
        GetComponent<Image>().color = alpha;
        // REMOVE PHOTO TAG
        this.gameObject.tag = "Untagged";

    }
}
