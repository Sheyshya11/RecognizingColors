using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlClear : MonoBehaviour
{

    previousLevel _previouslvl;

    void Start()
    {
        _previouslvl = FindObjectOfType<previousLevel>();


        if (PlayerPrefs.HasKey("LevelCleared"))
        {
           
        }
        else
        {
            PlayerPrefs.SetInt("LevelCleared", 0);
           
        



            if (PlayerPrefs.HasKey("LevelClearedCount"))
            {

            }
            else
            {
                PlayerPrefs.SetInt("LevelClearedCount", 0);
            }
        }
    }

    public void LevelCleared()
    {
        int previousBuildIndex = PlayerPrefs.GetInt("LevelCleared");
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int previousLevelCount = PlayerPrefs.GetInt("LevelClearedCount");
      


        if (currentBuildIndex > previousBuildIndex && !_previouslvl.isPreviousLevel)
        {
            PlayerPrefs.SetInt("LevelCleared", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("LevelClearedCount", previousLevelCount + 1);
            

        }
        
    }


    public void gameClear()
    {


        int previousBuildIndex = PlayerPrefs.GetInt("LevelCleared");
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;




        if (currentBuildIndex > previousBuildIndex && !_previouslvl.isPreviousLevel)
        {
            PlayerPrefs.SetInt("LevelCleared", SceneManager.GetActiveScene().buildIndex);



        }
    }

}
