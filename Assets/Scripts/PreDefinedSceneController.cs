using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreDefinedSceneController : MonoBehaviour 
{
	[SerializeField] Transform[] positions;//position where to instantiate the effects
	[SerializeField] GameObject[] effectPrefabs; //ambientOcc, bloom, chromaticAber, colorGrad, depthOfField, grain, lensDist, motionBlur, vignette;// effect prefabs
	string[] effects;

	// Use this for initialization
	void Start () 
	{
		effects = GameObject.Find("_ToggleLibrary").GetComponent<EnabledEffects>().effectList.ToArray();
		InitializeEffectsInTheScene();
	}
//write a function which will initialize where the effects supossed to be instantiaded
	void InitializeEffectsInTheScene()
	{
		for (int i = 0; i < positions.Length; i++)
		{
			for (int n = 0; n < effectPrefabs.Length; n++)
			{
				if (effects[i] == effectPrefabs[n].name)
				{
					GameObject effectInstance = Instantiate(effectPrefabs[n], positions[i].transform.position, positions[i].transform.rotation);
				}
			}
		}
	}
}
