using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

	[SerializeField] Button[] buttons;

	[SerializeField] TextMeshProUGUI Scoretxt;

	[SerializeField] Animator anim;
	[SerializeField] GameObject levelselect;
	[SerializeField] GameObject settingpanel;
	[SerializeField] GameObject scorePanel;
	

	bool display = false;
	



	// Use this for initialization
	void Start()
	{
		
		settingpanel.SetActive(false);
		levelselect.SetActive(false);
		scorePanel.SetActive(false);
		



		for (int i = 0; i < buttons.Length; i++)
		{
			
			buttons[i].interactable = false;
			anim.SetBool("Disabled", true);
			
		
		}

		if (!PlayerPrefs.HasKey("LevelClearedCount"))
        {
			PlayerPrefs.SetInt("LevelClearedCount", 0);
		}
			



		int clearedLevel = PlayerPrefs.GetInt("LevelClearedCount");
		for (int i = 0; i < clearedLevel + 1; ++i)
		{
			
				buttons[i].interactable = true;
		

		}
	}

/*	public void  unlockbtns() //for testing
    {
		for (int i = 0; i < buttons.Length; ++i)
		{

			buttons[i].interactable = true;

		}
		

	}*/
     


	public void levelToload(int level)
    {
		SceneManager.LoadScene(level);
    }
	
	public void resetPlayerPrefs()
    {
		for (int i = 1; i < buttons.Length; i++)
		{
			buttons[i].interactable = false;
			


		}
		PlayerPrefs.DeleteAll();
	


	}
	public void showScore()
	{
		
		if (!display)
        {
			Scoretxt.text = "Score: " + PlayerPrefs.GetInt("Score");
			display = true;
		}
		else
        {
			Scoretxt.text = "Score";
			display = false;

		}
		
	
	
	}
	public GameObject getLevelPanel()

    {
		return levelselect;

    }
	
	public GameObject getScorePanel()
	{
		return scorePanel;
	}

	public void quit()
    {
		Application.Quit();
		Debug.Log("Quit");
    }



}
