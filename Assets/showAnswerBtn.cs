using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class showAnswerBtn : MonoBehaviour
{
    public Sprite[] sprt;
   
    public int answeer;
    private void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprt[answeer];
    }
    
        
    
    private void Update()
    {
        
    }

    // Start is called before the first frame update


    // Update is called once per frame

}
