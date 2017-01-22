using UnityEngine;

public class ChargeBlock : MonoBehaviour {

	public float totalHeight;
	public float blockHeight;

	bool isGoingDown;

	public float downTime = 0.1f;

	public Transform model;

	public void Charge(int charge)
	{
		if (isGoingDown)
			return;

		if (model.localPosition.y >= totalHeight) {
			return;
		}
		
		var position = model.localPosition;

		position.y = blockHeight * charge;

		if (position.y > totalHeight) {
			position.y = totalHeight;
		}

		model.localPosition = position;
	
	}

	public void GoDown()
	{
		if (isGoingDown)
			return;

		isGoingDown = true;
	}

	public void Update()
	{
		if (isGoingDown) {
		
			// descend logic...
			float heightSpeed = totalHeight / downTime;

			var position = model.localPosition;

			position.y -= heightSpeed * Time.deltaTime;

			model.localPosition = position;

			if (model.localPosition.y < 0) {
				model.localPosition = new Vector3 (model.localPosition.x, 0.0f, model.localPosition.z);
				isGoingDown = false;
			}

		}
	}

	public void LocateCharacter(Transform transform)
	{
		transform.SetParent (model.transform, false);
	}
}
