using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeletePhotos : MonoBehaviour
{
   public void DeletePhoto()
    {
        Color alpha = GetComponent<Image>().color;
        alpha.a = 0f;
        GetComponent<Image>().color = alpha;
        this.gameObject.tag = "Untagged";
        // GetComponent<Image>().sprite
        // CLEAR IMAGE (Turn down alpha) 
        // REMOVE PHOTO TAG

    }
}
