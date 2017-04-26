﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {
	public float RotateSpeed;
	public float MoveSpeed;
	public GameObject ArmL, ArmR;

	private Rigidbody rb;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
	} 

	void FixedUpdate()
	{
        if (Input.GetKey(KeyCode.W))
			rb.AddForce(transform.forward * MoveSpeed);

        if (Input.GetKey(KeyCode.S))
			rb.AddForce(-transform.forward * MoveSpeed);

        Vector3 TurnLeft = new Vector3(0.0f, -RotateSpeed, 0.0f);
        Vector3 TurnRight = new Vector3(0.0f, RotateSpeed, 0.0f);

        Quaternion deltaRotation;
        if (Input.GetKey(KeyCode.A))
        {            
            deltaRotation = Quaternion.Euler(TurnLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
			ArmR.transform.RotateAround(transform.position, Vector3.up, -RotateSpeed * Time.deltaTime);
			ArmL.transform.RotateAround(transform.position, Vector3.up, -RotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            deltaRotation = Quaternion.Euler(TurnRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
			ArmR.transform.RotateAround(transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
			ArmL.transform.RotateAround(transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        }      
    }
}