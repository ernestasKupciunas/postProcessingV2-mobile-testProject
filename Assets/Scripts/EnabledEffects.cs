using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnabledEffects : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Toggle ambientOcc;
	[SerializeField] private Toggle bloom;
	[SerializeField] private Toggle chromaticAber;
	[SerializeField] private Toggle colorGrad;
	[SerializeField] private Toggle depthOfField;
	[SerializeField] private Toggle grain;
	[SerializeField] private Toggle lensDist;
	[SerializeField] private Toggle motionBlur;
	[SerializeField] private Toggle vignette;
	public List<string> effectList = new List<string>();// effects list

	void Start () 
	{
		SetupToggles();
		DontDestroyOnLoad(this.gameObject);
	}
	
	void ToggleValueChanged(Toggle change)
	{
		if (change.isOn)
		{
			effectList.Add(change.name);
			
			foreach (var effect in effectList)
			{
				Debug.Log("Selected effects are: " + effect);
			}
		}

		else
		{
			effectList.Remove(change.name);
			
			foreach (var effect in effectList)
			{
				Debug.Log("Selected effects are: " + effect);
			}
		}

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
}
