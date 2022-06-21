using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeToComplete;
    [SerializeField] float timeToShowCorrect;
    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestions;

    public bool isAnswering;
    public float timerValue;
    public bool alreadyAnswered = false;
    // Start is called before the first frame update
    void Update()
    {
        UpdatTimer();
    }
    public void cancelTimer()
    {
        timerValue = 0;
    }

    // Update is called once per frame
    private void UpdatTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnswering)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToComplete;


            }
            else
            {
                isAnswering = false;
                alreadyAnswered = true;
                timerValue = timeToShowCorrect;

            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToComplete;

            }
            else
            {

                isAnswering = true;
                timerValue = timeToComplete;
                loadNextQuestion = true;
            }
        }

    }
    public void stopTimerAnim()
    {
        Time.timeScale = 0f;
    }
    public void startTimerAnim()
    {
        Time.timeScale = 1f;
    }

}
