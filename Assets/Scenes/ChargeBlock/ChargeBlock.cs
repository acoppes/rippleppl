using UnityEngine;

public class ChargeBlock : MonoBehaviour {

	public float totalHeight;
	public float blockHeight;

	bool isFiring;

	public float downTime = 0.1f;

	public Transform model;

	public void Charge(int charge)
	{
		if (isFiring)
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

	public void Fire()
	{
		if (isFiring)
			return;

		isFiring = true;
	}

	public void Update()
	{
		if (isFiring) {
		
			// descend logic...
			float heightSpeed = totalHeight / downTime;

			var position = model.localPosition;

			position.y -= heightSpeed * Time.deltaTime;

			model.localPosition = position;

//			IncrementPositionY (model, -heightSpeed * Time.deltaTime);

			if (model.localPosition.y < 0) {
				model.localPosition = new Vector3 (model.localPosition.x, 0.0f, model.localPosition.z);
				isFiring = false;
			}

		}
	}
}
