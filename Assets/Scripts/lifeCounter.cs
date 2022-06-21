using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeCounter : MonoBehaviour
{
     int cutLife = 1;
     

    
    [SerializeField] GameObject Life;
     HardQuizManager _lifeValue;
    int currentLife;
  

    Text lifetxt;
    // Start is called before the first frame update
    void Start()
    {
        _lifeValue = FindObjectOfType<HardQuizManager>();
        lifetxt = GetComponent<Text>();

        if (PlayerPrefs.HasKey("Live"))

        {

        }
        else
        {
            PlayerPrefs.SetInt("Live", _lifeValue.getLifeValue());
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("Live") >= 0)
        {
            lifetxt.text = "Life: " + PlayerPrefs.GetInt("Live");
        }
        else
        {
            Life.SetActive(false);

        }





    }
    public void reduceLife(int lifeValue)
    {
 
        currentLife = lifeValue - cutLife;
     
        PlayerPrefs.SetInt("Live", currentLife);
    }
}
