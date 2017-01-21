using UnityEngine;

public class GameController : MonoBehaviour
{
	public int waveMaxPower = 5;

	public GameObject[] lanes;

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


}
