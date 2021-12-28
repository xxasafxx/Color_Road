using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
	private Handler handler;
	public ColorType type;
	public AudioSource AudioSource;
	[SerializeField] private Animation _anim = null;

	[Header("AudioClip")]
	[SerializeField] private AudioClip gameOverClip = null;
	[SerializeField] private AudioClip movigBallClip = null;
	[SerializeField] private AudioClip sphereClip = null;
	public AudioClip changeColorClip = null;

	private int randomSphereNum = 0;

	private void Start()
	{
		handler = FindObjectOfType<Handler>();
	}

	private void OnTriggerEnter(Collider other)
	{
		

		if (other.gameObject.CompareTag("ChackPoint"))
		{
			ChackPoint(other); // Chack what Obj to spawn by random number;
		}
		else
		{
			
			if (!other.gameObject.CompareTag("ChangeColor"))
			{
				ChackSphereType(other);
			}
		}
	}

	private void ChackPoint(Collider other)
	{
		other.gameObject.GetComponentInParent<Handler>().RoadMover();

		randomSphereNum = Random.Range(0, 8);


		if (randomSphereNum != 7)
		{
			other.gameObject.GetComponentInParent<Handler>().ChackSpawnOBJ(randomSphereNum);
		}
		else
		{
			other.gameObject.GetComponentInParent<Handler>().SpawnColorChangeBlock();
		}
	}

	private void ChackSphereType(Collider other)
	{
		Sphere sphere = other.gameObject.GetComponentInChildren<Sphere>();
		
		if (sphere.type != type) // if Ball type is not the same as Sphare type
		{
			UIHandler uIHandler = FindObjectOfType<UIHandler>();
			uIHandler.GetComponent<UIHandler>().GameOverUI();
			AudioSource.PlayOneShot(gameOverClip, 0.7f);

			_anim.Play("GameOver");
		}
		else
		{
			_anim.Play("Collect");

			if (sphere.IsMoving)
			{
				handler.UpdateScoreUI(2);
				AudioSource.PlayOneShot(movigBallClip, 0.3f);

			}
			else
			{

				handler.UpdateScoreUI(1);
				AudioSource.PlayOneShot(sphereClip, 0.3f);
			}
		}
	}
}
