using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuration : MonoBehaviour 
{

	[SerializeField] private Toggle preDefined;
	[SerializeField] private Toggle testManually;
	[SerializeField] private GameObject preDefinedEffectWindow, manualEffectWindow;
	// Use this for initialization
	void Start () 
	{
		preDefined.isOn = true;
		testManually.isOn = false;
		
		preDefinedEffectWindow.SetActive(true);
		manualEffectWindow.SetActive(false);
		InitializeToggles();
	}

	void InitializeToggles()
	{
		preDefined.onValueChanged.AddListener(delegate
		{	
			if (preDefined.isOn == true)
			{
				preDefinedEffectWindow.SetActive(true);
				manualEffectWindow.SetActive(false);
				Debug.Log("Pre-defined toggle is enabled");
			}
			ToggleChangingMode(preDefined, testManually);
		});

		testManually.onValueChanged.AddListener(delegate
		{
			if (testManually.isOn == true)
			{
				manualEffectWindow.SetActive(true);
				preDefinedEffectWindow.SetActive(false);
				Debug.Log("Manual toggle is enabled");
			}
			ToggleChangingMode(testManually, preDefined);
		});
	}

	void ToggleChangingMode(Toggle firstTogge, Toggle secondToggle)
	{
		if (firstTogge.isOn == true)
		{
			secondToggle.isOn = false;
		}
	}
}
