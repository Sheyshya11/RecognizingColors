using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtons : MonoBehaviour
{
    ListAudio listAudio;
    Settings settings;
   
   
    
    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<Settings>();
        listAudio = FindObjectOfType<ListAudio>();
       

    }


    /*public void PlayThroughScript()
    {
        listAudio.PlayButton();
    }*/
    public void ShowUI()
    {
        settings.GetUI().SetActive(true);
       
      
    }

    public void HideUI()
    {
        settings.GetUI().SetActive(false);
    
     
    }

        
}


