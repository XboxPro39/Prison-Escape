﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrisonEscape.Character;
public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] private float speed;
	[SerializeField] private float sprintSpeed;
	[SerializeField] private float stamina;
	[SerializeField] private float stamina_max = 500f;
	[SerializeField] public bool walking;
	[SerializeField] private float loseRate = 40f;
	[SerializeField] private float gainRate = 60f;
	private Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
	private Vector2 moveVelocity = this.GetComponent<Entity>();
	private Entity self;
	void Start()
	{
rb = this.GetComponent<Rigidbody2D>();
		self = this.GetComponent<Entity>();
		self.MaxStamina = (int) stamina_max;
		self.Stamina = (int) stamina;
		
	}

	void Update()
	{

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = input * speed;

		if (Input.GetKeyDown(KeyCode.LeftShift) && walking == false)
		{

			speed = sprintSpeed;
			self.Stamina -= (int) loseRate;

		}

		if(Input.GetKeyUp(KeyCode.LeftShift))
		{

			speed = 10f;
			self.Stamina += (int) gainRate;

		}

		if(stamina <= 0)
		{

			speed = 10f;
			walking = true;

		}

		if(stamina >= stamina_max)
		{
			walking = false;
            int maxStamina = self.MaxStamina;
            self.Stamina = maxStamina;

		}

	}

	void FixedUpdate()
	{

		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

	}

}
