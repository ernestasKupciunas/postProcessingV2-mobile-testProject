using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraAround : MonoBehaviour 
{
	[SerializeField] private Transform target;
	[SerializeField] private float rotationSpeed;


	// Use this for initialization
	void Start () 
	{
		if (target == null)
		{
			Debug.Log("Please add a target for the camera");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target != null)
		{
			gameObject.transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
		}
		else
		{
			Debug.Log("MainCamera gameObject is not enabled in the scene!!!");
		}
	}
}
