using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private GameObject GamePanel = null;
	[SerializeField] private GameObject GameOverPanel = null;
	[SerializeField] private GameObject GamePausePanel = null;

	public void GameOverUI()
	{
		GamePanel.SetActive(false);
		GameOverPanel.SetActive(true);

		BallMovement ballMovement = FindObjectOfType<BallMovement>();
		ballMovement.enabled = false;

		Handler handler = FindObjectOfType<Handler>();
		handler.ChackHIScoreUI();
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		GamePausePanel.SetActive(true);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		GamePausePanel.SetActive(false);
	}

	public void StartGame()
	{
		BallMovement ballMovement = FindObjectOfType<BallMovement>();
		ballMovement.enabled = true;
	}

	public void ResetGame()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
		BallMovement ballMovement = FindObjectOfType<BallMovement>();
		ballMovement.enabled = true;

	}
}
