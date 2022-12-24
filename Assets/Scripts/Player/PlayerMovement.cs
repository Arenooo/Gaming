using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _runSpeed;
	
	private Rigidbody _playersRigidBody;

	// Start is called before the first frame update
	void Start()
	{
		_playersRigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		_playersRigidBody.velocity = new Vector3(_runSpeed * Input.GetAxisRaw("Horizontal"), _playersRigidBody.velocity.y);
		_playersRigidBody.velocity = new Vector3(_playersRigidBody.velocity.x, _playersRigidBody.velocity.y, _runSpeed * Input.GetAxisRaw("Vertical"));
	}
}