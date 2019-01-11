using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{

	[SerializeField] private Toggle preDefined;
	[SerializeField] private Toggle ambientOcc;
	[SerializeField] private Toggle bloom;
	[SerializeField] private Toggle chromaticAber;
	[SerializeField] private Toggle colorGrad;
	[SerializeField] private Toggle depthOfField;
	[SerializeField] private Toggle grain;
	[SerializeField] private Toggle lensDist;
	[SerializeField] private Toggle motionBlur;
	[SerializeField] private Toggle vignette;
	[SerializeField] private Toggle manual;
	[SerializeField] private GameObject warningText;
	[SerializeField] private GameObject warningEffects;
	[SerializeField] private int effectCounter;

		void Start()
	{
		warningEffects.SetActive(false);
		warningText.SetActive(false);
		SetupToggles();
	}

	public void GoToTestScene()
	{
		if (preDefined.isOn == true && manual.isOn == true)
		{
			StartCoroutine("ThrowWarningSceneRun");
		}

		else if (effectCounter != 4 && preDefined.isOn)
		{
			StartCoroutine("ThrowWarningEffects");
		}
		else if(effectCounter == 4 && preDefined.isOn)
		{
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		}
		else if(manual.isOn)
		{
			SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
	}

	IEnumerator ThrowWarningSceneRun()
	{
		warningText.SetActive(true);
		yield return new WaitForSeconds(5f);
		warningText.SetActive(false);
	}
	IEnumerator ThrowWarningEffects()
	{
		warningEffects.SetActive(true);
		yield return new WaitForSeconds(5f);
		warningEffects.SetActive(false);
	}

	void SetupToggles()
	{
		ambientOcc.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(ambientOcc);
		});
		bloom.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(bloom);
		});
		chromaticAber.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(chromaticAber);
		});
		colorGrad.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(colorGrad);
		});
		depthOfField.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(depthOfField);
		});
		grain.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(grain);
		});
		lensDist.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(lensDist);
		});
		motionBlur.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(motionBlur);
		});
		vignette.onValueChanged.AddListener(delegate
		{
			ToggleValueChanged(vignette);
		});
	}

	void ToggleValueChanged(Toggle change)
	{
		if (change.isOn)
		{
			effectCounter ++;
		}
		else
		{
			effectCounter --;
		}
	}
}
