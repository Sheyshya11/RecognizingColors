using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPress : MonoBehaviour
{
    public AudioSource mouseClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void MouseClick()
    {
        mouseClick.Play();
    }
}
