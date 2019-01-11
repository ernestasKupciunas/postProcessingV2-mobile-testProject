using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTestButton : MonoBehaviour 
{
	GameObject toggleLibrary;

	void Start()
	{
		if (SceneManager.GetActiveScene().name == "PostProcessingv2MainTestingScene")
		{
			toggleLibrary = GameObject.Find("_ToggleLibrary");
			Debug.Log("ToggleLibraryNAme: " + toggleLibrary.gameObject.name.ToString());
		}
	}

	public void GoToConfigurationScene()
	{
		if (SceneManager.GetActiveScene().name == "PostProcessingv2MainTestingScene")
		{
			if (Time.timeScale != 1f)
			{
				Time.timeScale = 1f;
			}
			Destroy(toggleLibrary);
			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
		else if(SceneManager.GetActiveScene().name == "PostProcessingv2ManualTestingScene")
		{
			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
