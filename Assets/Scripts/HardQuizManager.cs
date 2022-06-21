using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Chimpvine.WebClient;


public class HardQuizManager : MonoBehaviour
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
    [SerializeField] GameObject GameOver; 

    [Header("Scores")]
    [SerializeField] Scorecounter scoreanim;
    public int scoreToAdd, retryscore;
    int sceneIndex, nextsceneIndex;
    int scoreValue;

    [Header("Audio")]
    [SerializeField] AudioSource win;
    [SerializeField] AudioSource incorrect;

    [Header("life")]
    [SerializeField] lifeCounter lifecount;
    [SerializeField] GameObject Resetlife;
    bool lifeRemain = true;
    private int currentLife;
    [SerializeField] int livevalue;

    [Header("Timer")]
    [SerializeField] Image Timerimg;
    Timer timer;
    bool hasAnsweredEarly;
    bool stop = false;


    [Header("Answer sprite")]
    [SerializeField] Sprite correctImg;
    Image answeImage;

    [SerializeField] int level;


    [SerializeField] GameObject settingpanel;

    private void Start()
    {

        timer = FindObjectOfType<Timer>();
        
        PlayerPrefs.SetInt("RetryScore", 0);

        youWinText.gameObject.SetActive(false);
        correctTxt.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        GoPanel.SetActive(false);
        GameOver.SetActive(false);
        Resetlife.SetActive(false);
        settingpanel.gameObject.SetActive(false);

         currentLife = PlayerPrefs.GetInt("Live");

        if (PlayerPrefs.GetInt("Live") > 0)
        {
            generateQuestion();
           
        }
        else
        {
            lifeRemain = false;
            QuizPanel.SetActive(false);
            GoPanel.SetActive(false);
            GameOver.SetActive(true);
            Resetlife.SetActive(true);
           
            
          
        }


        

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextsceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
      


    }
    private void Update()
    {

        if (!timer.alreadyAnswered && QnA.Count > 0 && !stop && lifeRemain)
        {
            Timerimg.fillAmount = timer.fillFraction;
        }
        

        if (timer.loadNextQuestion && !stop )
        {
            timer.alreadyAnswered = false;
            hasAnsweredEarly = false;
          
            timer.loadNextQuestion = false;
           
        }
        else if (!hasAnsweredEarly && !timer.isAnswering && lifeRemain)
        {
            if (QnA.Count>0)
            {
               
                lifecount.reduceLife(currentLife);
                int answer = QnA[currentQuestion].correctAnswerIndex;
                answeImage = options[answer - 1].GetComponent<Image>();
                answeImage.sprite = correctImg;

            }
           
            GoPanel.SetActive(true);
            Timerimg.fillAmount = timer.timeToComplete;
         
            stop = true;
            setButtonState(false);
        }
       


      

    }


    public int getLifeValue()
    {
        return livevalue;
    }

    public void retry()

    {
        retryScore();
        ChimpvineRestClient.SendGameUpdateRequest(level.ToString(), PlayerPrefs.GetInt("Score"));
        Debug.Log("level failed data sent");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void retryScore()
    {
        scoreValue = PlayerPrefs.GetInt("Score");
        retryscore = PlayerPrefs.GetInt("RetryScore");

        PlayerPrefs.SetInt("Score", scoreValue - retryscore);

        PlayerPrefs.SetInt("RetryScore", 0);
    }

    public void correct()
    {
        hasAnsweredEarly = true;
        stop = false;
        scoreanim.scored();
        win.Play();
        scoreanim.addScore(scoreToAdd);
       /* scoreanim.addScoreHardlvl(scoreToAdd);*/
        retryscore = PlayerPrefs.GetInt("RetryScore");
        PlayerPrefs.SetInt("RetryScore", retryscore + 3);

        correctTxt.gameObject.SetActive(true);
        QnA.RemoveAt(currentQuestion);

        if (QnA.Count == 0)
        {
            setButtonState(false);
            loadGamePanel();
        }
        else
        {
            setButtonState(false);
            Invoke("generateQuestion", 1f);
        }
        timer.cancelTimer();

    }
    void loadGamePanel()
    {

        correctTxt.gameObject.SetActive(false);
        levelSign.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
      
        Timerimg.fillAmount = timer.timeToComplete;


    }

    public void loadnextlvl()
    {
        PlayerPrefs.SetInt("RetryScore", 0);

        if ( sceneIndex == 12)
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
        stop = true;
        hasAnsweredEarly = true;
        incorrect.Play();
        lifecount.reduceLife(currentLife);
        scoreanim.unscored();
        if (PlayerPrefs.GetInt("Live") >= 0) //retry only if lifevalue exist
        {
            
            correctTxt.gameObject.SetActive(false);
            QuizPanel.SetActive(true);
            GoPanel.SetActive(true);
            
            displayAnswer();
         
        }
       else
        {
            GameOver.SetActive(true);       //gameover
            correctTxt.gameObject.SetActive(false);
            QuizPanel.SetActive(false);
            GoPanel.SetActive(false);
        }
       
     

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

        answeImage = options[answer - 1].GetComponent<Image>();
        answeImage.sprite = correctImg;
      
        correctAns.text = "The correct Answer is " + QnA[currentQuestion].Answers[answer - 1];
        if (options[answer - 1].CompareTag("Red"))
        {
            
            correctAns.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else if (options[answer - 1].CompareTag("Blue"))
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
            options[i].GetComponent<hard_answerScript>().isCorrect = false;

            if (QnA[currentQuestion].correctAnswerIndex == i + 1)
            {
                options[i].GetComponent<hard_answerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion()
    {

        
        
        correctTxt.gameObject.SetActive(false);
        setButtonState(true);
        if (QnA.Count > 0)
        {
            scoreanim.unscored();
            QuestionTxt.text = QnA[currentQuestion].Question;
            setAnswers();
        }
        else
        { setButtonState(false); }






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
    public void resetLife()
    {
         PlayerPrefs.SetInt("Live", livevalue);
        if (PlayerPrefs.GetInt("Score")>0)
        {
             PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - livevalue);
            /*PlayerPrefs.SetInt("hardScore", 0);*/

            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            SceneManager.LoadScene("mainMenu");

        }
      
    }

    private void OnDestroy()
    {
        Debug.Log("send level end data" + level.ToString());
        
    }

}
