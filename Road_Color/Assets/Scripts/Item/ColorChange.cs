using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
	public ColorType type;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			ChackColliderType(other);
		}
	}

	void Update()
	{

		if (transform.position.z <= Handler.camPosition.transform.position.z - 10f) //Destroy the Obj after 10m Behind the Camera 
		{
			Destroy(gameObject);
		}


	}

	private void ChackColliderType(Collider other)
	{
		BallHandler ballHandler = other.gameObject.GetComponent<BallHandler>();

		ballHandler.AudioSource.PlayOneShot(ballHandler.changeColorClip, 0.4f);

		if (ballHandler.type != type) // if Ball type is not the same as ColorChange type  
		{
			ballHandler.type = type;

			switch (type) //Change the color of the Ball and backgroundColor of the Camera
			{
				case ColorType.Yellow:
					ballHandler.GetComponent<MeshRenderer>().material.color = Color.yellow;
					ballHandler.GetComponentInChildren<TrailRenderer>().startColor = Color.yellow;
					Handler.camPosition.GetComponent<Camera>().backgroundColor = new Color32(255, 155, 0, 255);

					break;
				case ColorType.Blue:
					ballHandler.GetComponent<MeshRenderer>().material.color = Color.blue;
					ballHandler.GetComponentInChildren<TrailRenderer>().startColor = Color.blue;
					Handler.camPosition.GetComponent<Camera>().backgroundColor = new Color32(0, 128, 255, 255);
					
					break;
				case ColorType.Green:
					ballHandler.GetComponent<MeshRenderer>().material.color = Color.green;
					ballHandler.GetComponentInChildren<TrailRenderer>().startColor = Color.green;
					Handler.camPosition.GetComponent<Camera>().backgroundColor = new Color32(0, 255, 128, 255);

					break;

			}

		}
	}
}
