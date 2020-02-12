using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> collectables;
    private void Start()
    {
        // Get saved list 
        // check inventory at list(i)
        //// if list i == item number unlock item
       
        //for (int i = 0; i < collectables.Count; i++)
        //{

        //}
    }
    public void inventory(string itemName)
    {
      
        switch (itemName)
        {
            case "A":
                collectables[0].SetActive(true);
                break;
            case "B":
                collectables[1].SetActive(true);
                break;
            case "C":
                collectables[2].SetActive(true);
                break;
        }
    }
}
