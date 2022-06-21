using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hard_answerScript : MonoBehaviour
{
    public bool isCorrect = false;
    [SerializeField] HardQuizManager quizManager;
    public int scores, retryscore;



    public void Answer()
    {

        if (isCorrect)
        {

            Debug.Log("Correct");
            
            quizManager.correct();
        }
        else
        {

            Debug.Log("False");
            quizManager.wrong();
        }
    }
}
