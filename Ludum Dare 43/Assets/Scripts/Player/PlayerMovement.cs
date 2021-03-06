﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private float movementSpeed = 10;
	[SerializeField] private float gravity = 40f;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController charController;

	private bool walkSoundIsPlaying = false;
	//[SerializeField] AudioSource walkSound;

	void Start () {
		charController = GetComponent<CharacterController> ();
	}

	void Update () {
		//Movement
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= movementSpeed;
		moveDirection = Vector3.ClampMagnitude (moveDirection, movementSpeed);

		moveDirection.y -= gravity * Time.deltaTime;
		charController.Move (moveDirection * Time.deltaTime);


		//Audio feet
		//Vector2 horizontalMovement = new Vector2 (moveDirection.x, moveDirection.z);

		//if (horizontalMovement.magnitude != 0 && !walkSoundIsPlaying) {
		//	walkSoundIsPlaying = true;
		//	walkSound.Play ();

		//} else {
		//	walkSound.Stop ();
		//	walkSoundIsPlaying = false;
		//}
	}
}
