using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class selectYellow : MonoBehaviour
{

    public Button button;
    Color color6;
    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#FFFF00", out color6);
        button.GetComponent<Image>().color = color6;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
