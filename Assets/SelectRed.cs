using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectRed : MonoBehaviour
{
    public Button button;
    Color color1;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#f7071b", out color1);
        button.GetComponent<Image>().color = color1;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
