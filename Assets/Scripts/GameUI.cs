using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
	public Text playerText;

	public Button restartButton;

	public Color[] playerColors;

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
		int playerIndex = 1 - player.player;

		playerText.text = string.Format ("Player {0} Wins!", (playerIndex + 1));

		playerText.enabled = true;
		restartButton.enabled = true;

		playerText.color = playerColors [playerIndex];
	}
		
}
