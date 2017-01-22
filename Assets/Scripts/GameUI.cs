using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
	public Text playerText;

	public Button restartButton;

	public Color[] playerColors;

	bool showingVictory = false;

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Awake()
	{
		playerText.enabled = false;
		restartButton.enabled = false;

		restartButton.onClick.AddListener (delegate() {
//			Time.timeScale = 1.0f;
			Restart();
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

		showingVictory = true;
	}

	public void Update()
	{
		if (!showingVictory)
			return;
		
		if (Input.GetKeyUp (KeyCode.Return)) {
			Restart ();
		}

	}
		
}
