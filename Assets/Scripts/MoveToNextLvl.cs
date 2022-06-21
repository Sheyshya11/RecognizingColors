using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLvl : MonoBehaviour
{
    public int nextScene;
   

    // Start is called before the first frame update
    void Start()
    {
        
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
       
        
    }

    // Update is called once per frame
    public void loadNextLvl()
    {
      
       
        SceneManager.LoadScene(nextScene);
      
        
    }
}
