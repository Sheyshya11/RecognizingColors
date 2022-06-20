using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectBlack : MonoBehaviour
{
    public Button button;
    Color color5;
    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#000000", out color5);
        button.GetComponent<Image>().color = color5;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
