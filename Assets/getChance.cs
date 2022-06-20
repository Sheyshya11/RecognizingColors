using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getChance : MonoBehaviour
{
   
    public int chances;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public int   checkChances()
    {
      return chances -= 1;
        
        
    }
}
