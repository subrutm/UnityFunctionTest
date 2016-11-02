﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public float speed = 15.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller) {
//            Debug.Log("PlayerMove: Update");

            // プレイヤー機のコントローラ
            if (controller.isGrounded) {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                // ブーストキー入力
                if (Input.GetButton("Boost")) {
                    moveDirection.x *= 2;
                    moveDirection.z *= 2;
                }
            }

            if (Input.GetButton("Jump")) {
                if (moveDirection.y > 100)
                    moveDirection.y = 0;
                else
                    moveDirection.y += jumpSpeed * Time.deltaTime * ((Input.GetButton("Boost") == true) ? 2 : 1);
            } else {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}
