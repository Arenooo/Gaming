using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform _target;

	private float _lastXPosition;

	private void Start()
	{
		_lastXPosition = transform.position.x;
	}

	private void Update()
	{
		FollowTarget();
	}

	void FollowTarget()
	{
		transform.position = new Vector3(_target.position.x, transform.position.y, _target.position.z);
	}
}