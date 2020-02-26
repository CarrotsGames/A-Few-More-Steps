using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public GameObject noteUi;
    public Text noteText;
    public void ReadNote()
    {
        noteUi.transform.GetChild(0).GetComponent<Text>().text = noteText.text;
        noteUi.SetActive(true);
    }
}
