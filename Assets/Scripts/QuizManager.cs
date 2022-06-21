using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Chimpvine.WebClient;

public class QuizManager :MonoBehaviour
{

    [Header("Questions")]
    [SerializeField] List<QuestionSo> QnA;
    [SerializeField] GameObject[] options;
    public int currentQuestion;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI QuestionTxt;
    [SerializeField] TextMeshProUGUI correctAns;
    [SerializeField] TextMeshProUGUI Scoretxt;

    [SerializeField] GameObject youWinText;
    [SerializeField] GameObject correctTxt;
    [SerializeField] GameObject levelSign;

    [Header("Panel")]
    [SerializeField] GameObject QuizPanel;
    [SerializeField] GameObject GoPanel;
    [SerializeField] GameObject next;
   

    [Header("Audio")]
    [SerializeField] AudioSource win;
    [SerializeField] AudioSource incorrect;

    [Header("Scores")]
    [SerializeField] Scorecounter scoreanim;
    int sceneIndex, nextsceneIndex;
    public int scoreToAdd, retryscore;
    int scoreValue;

    [SerializeField] int level;

    [SerializeField] GameObject checkPreviousLevel;
    [SerializeField] GameObject settingpanel;

 
    private void Start()
    {
        

        youWinText.gameObject.SetActive(false);
        correctTxt.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        settingpanel.gameObject.SetActive(false);



        GoPanel.SetActive(false);
        generateQuestion();

        PlayerPrefs.SetInt("RetryScore", 0);
       
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextsceneIndex = SceneManager.GetActiveScene().buildIndex+1;

        

    }
    public int returnlvl(int level)
    {
        this.level = level;
        return this.level;
    }

    
    public void retry()

    {
        retryScore(); // avoid keep adding scores unlimitedly even after error.
        ChimpvineRestClient.SendGameUpdateRequest(level.ToString(), PlayerPrefs.GetInt("Score"));
        Debug.Log("level failed data sent");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
  public void retryScore()
    {
        scoreValue = PlayerPrefs.GetInt("Score");
        retryscore = PlayerPrefs.GetInt("RetryScore");

        PlayerPrefs.SetInt("Score", scoreValue - retryscore);
        PlayerPrefs.SetInt("RetryScore", 0);
    }
    
    public void correct()
    {

        if(!checkPreviousLevel.GetComponent<previousLevel>().isPreviousLevel) //if not previous level
        {
            retryscore = PlayerPrefs.GetInt("RetryScore");
            if (sceneIndex < 5)
            {
                scoreanim.addScore(scoreToAdd);
               
                PlayerPrefs.SetInt("RetryScore", retryscore + 1);

            }
            else
            {
                scoreanim.addScore(scoreToAdd);
            
                PlayerPrefs.SetInt("RetryScore", retryscore + 2);
            }

        }
        


        scoreanim.scored();
        win.Play();
        correctTxt.gameObject.SetActive(true);
        QnA.RemoveAt(currentQuestion);
       
        if (QnA.Count==0)
        {
            setButtonState(false);
            loadGamePanel(); 
        }
        else
        {
            setButtonState(false);
            Invoke("generateQuestion", 1f);
        }    
        
       
    }
    void loadGamePanel()
    {
        
        correctTxt.gameObject.SetActive(false);
        levelSign.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
        

        
    }

     public void loadnextlvl()
    {
        PlayerPrefs.SetInt("RetryScore",0);

        if (sceneIndex ==  12)
        {

            ChimpvineRestClient.SendGameUpdateRequest((level + 1).ToString(), PlayerPrefs.GetInt("Score"));
            Debug.Log("level completed data sent");
            Invoke("loadMainMenu", 1f);

        }
        else
        {

            ChimpvineRestClient.SendGameUpdateRequest((level + 1).ToString(), PlayerPrefs.GetInt("Score"));
            Debug.Log("level completed data sent");
            Invoke("loadNextScene", 2f);


        }
    }

    void loadNextScene()
    {
        
        SceneManager.LoadScene(nextsceneIndex);
        generateQuestion();
        
    }
    public void wrong()
    {
        incorrect.Play();
        correctTxt.gameObject.SetActive(false);
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        displayAnswer();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void displayAnswer()
    {
        Color orange;
        Color purple;
        Color pink;
        ColorUtility.TryParseHtmlString("#fc6203", out orange); 
        ColorUtility.TryParseHtmlString("#6a0dad", out purple);
        ColorUtility.TryParseHtmlString("#ed058c", out pink);
        //EF54A1



        int answer = QnA[currentQuestion].correctAnswerIndex;
        switch(level)
        {
            case 1:
                SceneManager.LoadScene(0);
                break;
            case 2:
                SceneManager.LoadScene(1);
                break;
            case 3:
                SceneManager.LoadScene(2);
                break;






        }
        correctAns.text ="The correct Answer is "+ QnA[currentQuestion].Answers[answer-1];
        if (options[answer-1].CompareTag("Red"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (options[answer-1].CompareTag("Blue"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = Color.blue;
        }
        else if (options[answer - 1].CompareTag("Orange"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = orange;
        }

        else if (options[answer - 1].CompareTag("Green"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        else if (options[answer - 1].CompareTag("Purple"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = purple;
        }
        else if (options[answer - 1].CompareTag("Black"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        else if (options[answer - 1].CompareTag("Yellow"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        else if (options[answer - 1].CompareTag("Pink"))
        {
            correctAns.GetComponent<TextMeshProUGUI>().color = pink;
        }








    }
    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
           
            if (QnA[currentQuestion].correctAnswerIndex==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion()
    {
      
        correctTxt.gameObject.SetActive(false);
        setButtonState(true);
        if ( QnA.Count>0)
        {

            scoreanim.unscored();
            QuestionTxt.text = QnA[currentQuestion].Question;
            setAnswers();
        }
       
       




    }
    public void loadMainMenu()
    {
        retryScore();
        SceneManager.LoadScene("mainMenu");

    }
    
    void setButtonState(bool state)
    {
        for (int i = 0; i < options.Length; i++)
        {
            Button tempBtn = options[i].GetComponent<Button>();
            tempBtn.interactable = state;
        }
    }

    

}
