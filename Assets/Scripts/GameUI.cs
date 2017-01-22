using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
	public Text playerText;

	public Button restartButton;

	void Awake()
	{
		playerText.enabled = false;
		restartButton.enabled = false;

		restartButton.onClick.AddListener (delegate() {
//			Time.timeScale = 1.0f;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
	}

	public void ShowPlayerWin (Player player)
	{
//		Time.timeScale = 0.0f;
		playerText.text = string.Format ("Player {0} Wins!", player.player);

		playerText.enabled = true;
		restartButton.enabled = true;
	}
		
}
