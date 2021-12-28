using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] private float barrierXmin = -2.5f;
	[SerializeField] private float barrierXMax = 2.5f;
	Vector3 mouseLastPos = Vector3.zero;

	void Update()
	{
		transform.Translate(Vector3.forward *speed *  Time.deltaTime);

		//MouseInput();
		FingerInput();

		IncreaseSpeed();
	}

	private void IncreaseSpeed()
	{
		if(Handler.score >= 2)
		{
			speed += Time.deltaTime * 0.04f;
		}
	}

	private void FingerInput()
	{
		if (Input.touchCount > 0)
		{
			Vector3 fingerPos = Input.touches[0].position;
			fingerPos.z = 10;
			fingerPos = Camera.main.ScreenToWorldPoint(fingerPos);
			if (mouseLastPos == Vector3.zero)
			{
				mouseLastPos = fingerPos;
			}

			fingerPos = new Vector3(fingerPos.x, transform.position.y, transform.position.z);

			MovePlayer(fingerPos);
		}
		else
		{
			mouseLastPos = Vector3.zero;
		}
	}

	private void MouseInput()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);

			if (mouseLastPos == Vector3.zero)
			{
				mouseLastPos = mousePos;
			}
			mousePos = new Vector3(mousePos.x, transform.position.y, transform.position.z);
			MovePlayer(mousePos);
		}
		else
		{
			mouseLastPos = Vector3.zero;
		}
	}

	//Moving between the barrierXmin and barrierXMax X positions
	public void MovePlayer(Vector3 mousePos)
	{
		//move diraction
		int dir = 0;
		dir = (mouseLastPos.x < mousePos.x) ? 1 : -1;

		//clamp between min-max
		float xPos = transform.position.x + Mathf.Abs(mouseLastPos.x - mousePos.x) * dir;
		xPos = Mathf.Clamp(xPos, barrierXmin, barrierXMax);
		transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

		mouseLastPos = mousePos;
	}
}
