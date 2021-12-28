using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Handler : MonoBehaviour
{
	[HideInInspector] public static Transform camPosition = null;

	[Header("SpawnOBJ")]
	[SerializeField] private GameObject[] sphereList = null;
	[SerializeField] private GameObject[] movingSphereList = null;
	[SerializeField] private GameObject[] colorChangeList = null;

	[Header("SpawnRoads")]
	[SerializeField] private List<GameObject> roadList = null;
	private float roadOffSet = 14f;
	
	[Header("Score")]
	[SerializeField] private Text scoreText = null;
	[SerializeField] private Text highscoreText = null;
	[Space]
	[SerializeField] private Text G_O_scoreText = null;
	[SerializeField] private Text G_O_highscoreText = null;
	[SerializeField] private Text UIPlusscoreText = null;
	public static int score = 0;

	[Header("Animation")]
	[SerializeField] private Animation UIPlusanim = null;

	private void Start()
	{
		score = 0;

		highscoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
		
		camPosition = FindObjectOfType<Cam>().transform;
		ChackHIScoreUI();
	}

	public void ChackSpawnOBJ(int random)
	{

		if (random <= 4 && random >= 0)
		{
			SpawnSphare();
		}
		else if (random <= 6 && random >= 5)
		{
			SpawnMovingSphare();
		}
	}


	private void SpawnSphare()
	{
		Instantiate(sphereList[Random.Range(0, sphereList.Length)], new Vector3(camPosition.transform.position.x, .5f, camPosition.GetChild(0).transform.position.z), Quaternion.identity);
		
	}

	private void SpawnMovingSphare()
	{
		GameObject temp = Instantiate(movingSphereList[Random.Range(0, movingSphereList.Length)], new Vector3(camPosition.transform.position.x, .5f, camPosition.GetChild(0).transform.position.z), Quaternion.identity);
		temp.GetComponent<Sphere>().IsMoving = true;
	}

	public void SpawnColorChangeBlock()
	{
		Instantiate(colorChangeList[Random.Range(0, colorChangeList.Length)], new Vector3(camPosition.transform.position.x, 0.5f, camPosition.GetChild(0).transform.position.z), Quaternion.identity);
	}

	public void RoadMover()
	{
		GameObject movedRoad = roadList[0];
		roadList.Remove(movedRoad);
		float newZ = roadList[roadList.Count - 1].transform.position.z + roadOffSet;
		movedRoad.transform.position = new Vector3(0f, 0f, newZ);
		roadList.Add(movedRoad);
	}

	public void UpdateScoreUI(int num)
	{
		score += num;
		scoreText.GetComponent<Text>().text = score.ToString();
		UIPlusscoreText.text = "+" + num.ToString();
		UIPlusanim.Play();
	}

	public void ChackHIScoreUI()
	{
		G_O_scoreText.GetComponent<Text>().text = score.ToString();

		if (score > PlayerPrefs.GetInt("highScore", 0))
		{
			PlayerPrefs.SetInt("highScore", score);
		}

		G_O_highscoreText.text = "Best:" + PlayerPrefs.GetInt("highScore", 0).ToString();
	}
}
