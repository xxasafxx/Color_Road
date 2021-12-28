using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
	public ColorType type;

	public bool IsMoving = false;
	private int speedAmount = 5;

	void Update()
    {

		if (IsMoving)
		{
			if (transform.position.x <= -2)
			{
				speedAmount = 5;
			}
			else if(transform.position.x >= 2.5f)
			{
				speedAmount = -5;
			}
			transform.Translate(speedAmount * Time.deltaTime, 0, 0);
		}

		if (transform.position.z <= Handler.camPosition.transform.position.z - 10f)  //Destroy the Obj after 10m Behind the Camera 
		{
			Destroy(gameObject);
		}
	}
}

public enum ColorType
{
	Yellow,
	Blue,
	Green 
}
