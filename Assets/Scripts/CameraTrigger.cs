using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTrigger : MonoBehaviour 
{
	[SerializeField] private Text effectNametxt;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PostProcessEffect")
		{
			effectNametxt.text = other.transform.name;
		}
	}
}
