using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

	// Resume Game
	public void ResumeGame () {
		Time.timeScale = 1;
	}

	// Restart Game
	public void RestartGame () {
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	// Quit Game
	public void QuitGame () {
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

}
