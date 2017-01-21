using UnityEngine;
using System.Collections;

public class TestWaveBlockAnimation : MonoBehaviour {

	public enum State
	{
		Idle,
		Up, 
		Down
	}

	public Transform model;

//	bool animating;

	float upTime;

	float[] downTimes;

	float blockHeight;

	float totalHeight;

	State state = State.Idle;

	public void PlayAnimation(int power, BlockConfig config)
	{
		PlayAnimation (power, config.upTime, config.downTime, config.blockHeight);
	}

	public void PlayAnimation(int power, float upTime, float[] downTimes, float blockHeight)
	{
		this.upTime = upTime;
		this.downTimes = downTimes;
		this.blockHeight = blockHeight;

		totalHeight = power * blockHeight;

		StartUp ();
	}

	void StartUp()
	{
		this.state = State.Up;
	}

	void StartDown()
	{
		this.state = State.Down;
	}

	void StartIdle()
	{
		this.state = State.Idle;
	}

	void IncrementPositionY(Transform t, float y)
	{
		t.localPosition = t.localPosition + new Vector3 (0, y, 0);
	}

	void Update()
	{
		if (state == State.Idle) {

		} else if (state == State.Up) {

			float heightSpeed = totalHeight / upTime;
			IncrementPositionY (model, heightSpeed * Time.deltaTime);

			if (model.localPosition.y > totalHeight) {
				model.localPosition = new Vector3 (model.localPosition.x, totalHeight, model.localPosition.z);

				StartDown ();
			}
			
		} else if (state == State.Down) {

			var downTime = Mathf.Lerp (downTimes [1], downTimes [0], model.localPosition.y / (5 * blockHeight));

			float heightSpeed = totalHeight / downTime;

			IncrementPositionY (model, -heightSpeed * Time.deltaTime);

			if (model.localPosition.y < 0) {
				model.localPosition = new Vector3 (model.localPosition.x, 0.0f, model.localPosition.z);
				StartIdle ();
			}
				
		}
	}
}
