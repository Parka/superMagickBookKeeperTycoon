using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowObject : MonoBehaviour {

	public GameObject objectToFollow;
	[SerializeField]
	private float horizontalMargin = 2;
	[SerializeField]
	private float verticalMargin = 2;
	//[SerializeField]
	//private float movementSpeed = 10000000f;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - objectToFollow.transform.position;		
	}

	// Update is called once per frame
	void LateUpdate () {
		
		offset = objectToFollow.transform.position - transform.position;
		offset.z = 0;
		if (offset.x > horizontalMargin)
			offset.x -= horizontalMargin;
		else if (offset.x < -horizontalMargin)
			offset.x += +horizontalMargin;
		else
			offset.x = 0;
		if (offset.y > verticalMargin)
			offset.y -= verticalMargin;
		else if (offset.y < -verticalMargin)
			offset.y += +verticalMargin;
		else
			offset.y = 0;
		transform.position += offset;
	}
}

