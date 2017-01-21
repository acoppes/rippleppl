using UnityEngine;
using System.Collections;

public class TestWaveBlockAnimation : MonoBehaviour {

	public Transform model;

	bool animating;

	float upTime;
	float downTime;

	float blockHeight;


	public void PlayAnimation(int power, float upTime, float downTime, float blockHeight)
	{
		if (animating)
			return;

		this.upTime = upTime;
		this.downTime = downTime;
		this.blockHeight = blockHeight;

		StartCoroutine(PlayAnimationRoutine(power));
	}

	void IncrementPositionY(Transform t, float y)
	{
		t.localPosition = t.localPosition + new Vector3 (0, y, 0);
	}

	IEnumerator PlayAnimationRoutine(int power)
	{
		animating = true;

		float totalHeight = power * blockHeight;

		float heightSpeed = totalHeight / upTime;

		while (model.localPosition.y < totalHeight) {
			yield return null;
			IncrementPositionY (model, heightSpeed * Time.deltaTime);
		}

		model.localPosition = new Vector3 (model.localPosition.x, totalHeight, model.localPosition.z);

		heightSpeed = totalHeight / downTime;

		while (model.localPosition.y > 0) {
			yield return null;
			IncrementPositionY (model, -heightSpeed * Time.deltaTime);
		}

		model.localPosition = new Vector3 (model.localPosition.x, 0.0f, model.localPosition.z);

		animating = false;
	}
}
