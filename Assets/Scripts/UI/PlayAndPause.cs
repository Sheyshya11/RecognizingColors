using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndPause : MonoBehaviour
{
    [SerializeField] GameObject inGameSettings;
    [SerializeField] GameObject tutorial;

    private void Update()
    {
        TutorialAndUI();

    }

    private void TutorialAndUI()
    {
        if (tutorial.activeSelf)
        {
            StopTime();
        }
        else
        {
            if (inGameSettings.activeSelf)
            {
                StopTime();
            }
            else
            {
                StartTime();
            }
        }
    }

    public void StartTime()
    {
        Time.timeScale = 1f;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
