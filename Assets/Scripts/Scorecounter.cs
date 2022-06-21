using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scorecounter : MonoBehaviour
{
    public  int scoreValue = 0;
   /* int hardScoreValue=0;*/
    
    [SerializeField] Animator scoreanim;
   



    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
     
        score.text = "Score:" + PlayerPrefs.GetInt("Score");


    }
    public void addScore(int scores)
    {
       
        scoreValue = PlayerPrefs.GetInt("Score");
        scoreValue = scoreValue + scores;

        PlayerPrefs.SetInt("Score", scoreValue);


    }
   
   


    public void scored()

    {
        scoreanim.SetTrigger("scored");
    }
    public void unscored()
    {
        scoreanim.SetTrigger("notscored");
    }
}
