using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsonoff : MonoBehaviour
{
    
    
    [SerializeField] Sprite settingSprite;
    [SerializeField] Image settingImage;


    // Start is called before the first frame update
    void Start()
    {
       
        settingImage.sprite = settingSprite;
        


    }

    // Update is called once per frame
 
}
