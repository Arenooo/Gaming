using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _runSpeed;
	
	private Rigidbody _playersRigidBody;

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
		_playersRigidBody.velocity = new Vector3(_runSpeed * Input.GetAxisRaw("Horizontal"), _playersRigidBody.velocity.y);
		_playersRigidBody.velocity = new Vector3(_playersRigidBody.velocity.x, _playersRigidBody.velocity.y, _runSpeed * Input.GetAxisRaw("Vertical"));
	}
}