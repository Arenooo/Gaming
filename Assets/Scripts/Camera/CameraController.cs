using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform _target;

	private float _lastXPosition;

	// Start is called before the first frame update
	void Start()
	{
		_lastXPosition = transform.position.x;
	}

	// Update is called once per frame
	void Update()
	{
		FollowTarger();
	}

	void FollowTarger()
	{
		transform.position = new Vector3(_target.position.x, transform.position.y, _target.position.z);
	}
}