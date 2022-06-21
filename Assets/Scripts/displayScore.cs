using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayScore : MonoBehaviour
{
    [SerializeField] MainMenu score;
    [SerializeField] Text scoretxt;
    [SerializeField] GameObject scorebtn;


    // Start is called before the first frame update


    // Update is called once per frame
   

    public void ShowUI()
    {
        
        score.getScorePanel().SetActive(true);
        scoretxt.text = "SCORE: " + PlayerPrefs.GetInt("Score");
   
        




    }

    public void HideUI()
    {
        score.getScorePanel().SetActive(false);
    
       


    }

}
