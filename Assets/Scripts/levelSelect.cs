using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    MainMenu levelselect;

   
    // Start is called before the first frame update
    void Start()
    {
        levelselect = FindObjectOfType<MainMenu>();
      


    }

    // Update is called once per frame
    public void ShowUI()
    {
        levelselect.getLevelPanel().SetActive(true);
      
      

    }

    public void HideUI()
    {
        levelselect.getLevelPanel().SetActive(false);
   
     
    }
}
