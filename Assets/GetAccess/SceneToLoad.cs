using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Chimpvine.WebClient;

public class SceneToLoad : MonoBehaviour
{
    public int Leveltoload;


   
   

    // Start is called before the first frame update

    // Update is called once per frame
    public void levelToLoad()
    {
        
        SceneManager.LoadScene(Leveltoload);
        sendlevelDataStart();
    }


    public void sendlevelDataStart()
    {
        ChimpvineRestClient.SendGameStartRequest(Leveltoload.ToString());
        Debug.Log(Leveltoload);
    }
    public void sendUpdateData()
    {
        ChimpvineRestClient.SendGameUpdateRequest(Leveltoload.ToString(), 0);

    }
}
