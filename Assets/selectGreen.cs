using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class selectGreen : MonoBehaviour
{
    public Button button;
    Color color2;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#0afc47", out color2);
        button.GetComponent<Image>().color = color2;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
