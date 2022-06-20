using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectBlue : MonoBehaviour
{
    public Button button;
    Color color4;
    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#0932d9", out color4);
        button.GetComponent<Image>().color = color4;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
