using UnityEngine;
using System.Collections;

public class TestWaveBlockAnimation : MonoBehaviour {

	public float upTime;
	public float downTime;

	public float blockHeight;

	public Transform model;

	bool animating;

	// Update is called once per frame
	void Update () {

		if (animating)
			return;

		KeyCode[] powerKeys = new KeyCode[] {
			KeyCode.Alpha1,
			KeyCode.Alpha2,
			KeyCode.Alpha3,
			KeyCode.Alpha4,
			KeyCode.Alpha5
		};

		for (int i = 0; i < powerKeys.Length; i++) {
			if (Input.GetKeyUp (powerKeys [i])) {
				StartCoroutine (PlayAnimation (i + 1));
			}
		}

	}

	void IncrementPositionY(Transform t, float y)
	{
		t.localPosition = t.localPosition + new Vector3 (0, y, 0);
	}

	IEnumerator PlayAnimation(int power)
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
