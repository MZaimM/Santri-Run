using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour {

	public GameObject groundDestructionPoint;


	// Use this for initialization
	void Start () {
		groundDestructionPoint = GameObject.Find("GroundDestroyPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < groundDestructionPoint.transform.position.x) {			
			gameObject.SetActive (false);
		}
	}
}
