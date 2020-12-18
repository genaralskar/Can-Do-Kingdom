using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardDirection : MonoBehaviour
{
	public Vector3 direction;
	Transform tr;
	Transform parentTransform;

	//Setup;
	void Start()
	{
		tr = transform;
		parentTransform = transform.parent;
	}

	//Update;
	void LateUpdate()
	{

		if (direction == Vector3.zero)
			return;

		//Calculate up and forward direction;
		Vector3 _forwardDirection = Vector3.ProjectOnPlane(direction, parentTransform.up).normalized;
		Vector3 _upDirection = parentTransform.up;

		//Set rotation;
		tr.rotation = Quaternion.LookRotation(_forwardDirection, _upDirection);
	}
}