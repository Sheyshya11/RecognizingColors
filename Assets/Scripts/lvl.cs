using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class lvl : MonoBehaviour
{

	TextMeshProUGUI text;
	int sceneIndex;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	// Update is called once per frame
	void Update()
	{
		text.text = "LEVEL " + sceneIndex;
	}
}
