using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectPurple : MonoBehaviour
{
    public Button button;
    Color color7;
    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#800080", out color7);
        button.GetComponent<Image>().color = color7;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
