using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {	
	[SerializeField] public Transform generationPoint;
	[SerializeField] public float distanceBetween;

	private float groundWidth;

	[SerializeField] public float distanceBetweenMin;
	[SerializeField] public float distanceBetweenMax;	
	private int groundSelector;
	private float[] groundWidths;

	[SerializeField] public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;


	// Use this for initialization
	void Start () {			

		groundWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
		
			groundWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;	
		
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			groundSelector = Random.Range (0, theObjectPools.Length);
		
			heightChange = minHeight + Random.Range(maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
			
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
			

				heightChange = minHeight;
			
			}

			transform.position = new Vector3 (transform.position.x + (groundWidths[groundSelector] / 2) + distanceBetween, heightChange, transform.position.z);			

			GameObject newGround =  theObjectPools[groundSelector].GetPooledObject ();
		
			newGround.transform.position = transform.position;
			newGround.transform.rotation = transform.rotation;
			newGround.SetActive (true);


			transform.position = new Vector3 (transform.position.x + (groundWidths[groundSelector] / 2), transform.position.y, transform.position.z);
		}

	}
}