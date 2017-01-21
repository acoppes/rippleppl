using UnityEngine;

public class GameController : MonoBehaviour
{
	public int waveMaxPower = 5;

	public GameObject[] lanes;

	int[] playerLayers = new int[2];
	int[] waveLayers = new int[2];

	void Awake()
	{
		playerLayers[0] = LayerMask.NameToLayer ("Player1");
		playerLayers[1] = LayerMask.NameToLayer ("Player2");

		waveLayers[0] = LayerMask.NameToLayer ("Wave1");
		waveLayers[1] = LayerMask.NameToLayer ("Wave2");
	}

	public int GetLaneUp(int lane)
	{
		return Mathf.Clamp (lane - 1, 0, lanes.Length - 1);
	}

	public int GetLaneDown(int lane)
	{
		return Mathf.Clamp (lane + 1, 0, lanes.Length - 1);
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

}
