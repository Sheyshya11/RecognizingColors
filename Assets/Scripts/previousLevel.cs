using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class previousLevel : MonoBehaviour
{
    public bool isPreviousLevel = true;
    // Start is called before the first frame update
    void Start()
    {
        int previousBuildIndex = PlayerPrefs.GetInt("LevelCleared");
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        



        if (currentBuildIndex <= previousBuildIndex)
        {
            isPreviousLevel = true;


        }
        else
        {
            isPreviousLevel = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
