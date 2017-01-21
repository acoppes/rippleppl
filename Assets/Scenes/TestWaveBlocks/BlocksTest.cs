using UnityEngine;
using System.Collections;

public class BlocksTest : MonoBehaviour {

	public TestWaveBlockAnimation[] blocks;
	public float timeBetweenBlocks;

	public float upTime;
	public float[] downTimes;

	public float blockHeight;

	// Update is called once per frame
	void Update () {
		var power = GetPower ();

		if (power == 0)
			return;

		StartCoroutine(BlocksAnimations (power));
	}

	IEnumerator BlocksAnimations(int power)
	{
		for (int i = 0; i < blocks.Length; i++) {
			blocks [i].PlayAnimation (power, upTime, downTimes, blockHeight);
			yield return new WaitForSeconds (timeBetweenBlocks);
		}

		yield return null;
	}

	int GetPower()
	{
		KeyCode[] powerKeys = new KeyCode[] {
			KeyCode.Alpha1,
			KeyCode.Alpha2,
			KeyCode.Alpha3,
			KeyCode.Alpha4,
			KeyCode.Alpha5
		};

		for (int i = 0; i < powerKeys.Length; i++) {
			if (Input.GetKeyUp (powerKeys [i])) {
				return i + 1;
			}
		}

		return 0;
	}



}
