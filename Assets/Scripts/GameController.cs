using UnityEngine;

public class GameController : MonoBehaviour
{
	public int waveMaxPower = 5;

	public Lane[] lanes;

	public GameLogicData data;

	public GameUI gameUi;

    public CameraModel camera;

	int[] playerLayers = new int[2];
	int[] waveLayers = new int[2];

	public Player[] players;

	public PlayerController[] playerControllers;

	void Awake()
	{
		playerLayers[0] = LayerMask.NameToLayer ("Player1");
		playerLayers[1] = LayerMask.NameToLayer ("Player2");

		waveLayers[0] = LayerMask.NameToLayer ("Wave1");
		waveLayers[1] = LayerMask.NameToLayer ("Wave2");
	}

	void Start()
	{
		// locate players in middle lane

	}

	public ChargeBlock GetChargeBlock(int player, int lane)
	{
		return lanes [lane].GetChargeBlock(player);
	}

	public int GetLaneUp(int lane)
	{
		return Mathf.Clamp (lane - 1, 0, lanes.Length - 1);
//		int otherLane = Mathf.Clamp (lane - 1, 0, lanes.Length - 1);
//		return lanes [otherLane];
	}

	public int GetLaneDown(int lane)
	{
		return Mathf.Clamp (lane + 1, 0, lanes.Length - 1);
//		int otherLane = Mathf.Clamp (lane + 1, 0, lanes.Length - 1);
//		return lanes [otherLane];
	}

	public float GetLaneVerticalPosition(int lane)
	{
		return lanes[lane].transform.position.y;
	}

	public int GetWaveLayer(int playerLayer)
	{
		if (playerLayer == playerLayers [0])
			return waveLayers [0];
		return waveLayers [1];
	}

	public float GetChargeTime(int wavePower)
	{
		if (wavePower >= waveMaxPower)
			wavePower = waveMaxPower - 1;
		return data.waveChargeTimes[wavePower];
	}

	bool playerWin = false;

	public void OnBaseDeath(Base playerBase)
	{
		if (playerWin)
			return;

		playerWin = true;

		var inputs = GameObject.FindObjectsOfType<PlayerInput> ();
		foreach (var i in inputs) {
			i.enabled = false;
		}

		var waves = GameObject.FindObjectsOfType<Wave> ();
		foreach (var wave in waves) {
			Destroy (wave);
		}

		var players = GameObject.FindObjectsOfType<PlayerController> ();
		foreach (var player in players) {
			player.enabled = false;
		}

		gameUi.ShowPlayerWin (this.players[playerBase.player]);

		foreach (var playerController in playerControllers) {
			if (playerController.player == playerBase.player) {
				playerController.model.GetModel ().Defeat ();
			} else {
				playerController.model.GetModel ().Victory ();
			}
		}
	}

    public void shakeCamera(float time, float maxX = .1f, float maxY = .1f, float shakeInterval = 0.05f)
    {
        camera.shake(time, maxX, maxY, shakeInterval);
    }

}
