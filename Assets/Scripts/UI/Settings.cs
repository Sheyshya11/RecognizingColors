using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject UI;

    [SerializeField] Slider brightnessSlider;
    [SerializeField] Slider contrastSlider;
    [SerializeField] Slider saturationSlider;
  /*  public SO_gameObject soCamera;*/

    public Canvas canvas;

    private void Start()
    {
        /*canvas = GetComponent<Canvas>();*/
        GetCamera();
    }


    private void Update()
    {
       /* if (canvas.worldCamera == null)
        {
            GetCamera();
        }*/
    }
    public void GetCamera()
    {
        canvas.worldCamera = Camera.main;
       /* canvas.worldCamera = soCamera._gameobject.GetComponent<Camera>();*/
    }

    public GameObject GetUI()
    {
        return UI;
    }
    public Slider GetBrightness()
    {

        return brightnessSlider;
    }

    public Slider GetContrast()
    {
        return contrastSlider;
    }

    public Slider GetSaturation()
    {
        return saturationSlider;
    }
}


