using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance;
	
	[SerializeField] private float _speed;
	
	private Rigidbody _playersRigidBody;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_playersRigidBody = GetComponent<Rigidbody>();
	}

	private void Update()
	{	
		MovePlayer();
	}

	private void MovePlayer()
	{
		_playersRigidBody.velocity = new Vector3(_speed * 10 * Input.GetAxisRaw("Horizontal"), _playersRigidBody.velocity.y);
		_playersRigidBody.velocity = new Vector3(_playersRigidBody.velocity.x, _playersRigidBody.velocity.y, _speed * 10 * Input.GetAxisRaw("Vertical"));
	}
}