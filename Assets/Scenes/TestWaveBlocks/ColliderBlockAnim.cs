using UnityEngine;

public class ColliderBlockAnim : MonoBehaviour {

	public int testPower;

	public BlockConfig blockConfig;

	public float speed = 1.0f;

	void Update()
	{
		transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {

		var block = otherCollider.GetComponent<TestWaveBlockAnimation> ();

		if (block != null) {
			block.PlayAnimation (testPower, blockConfig);
		}

		Debug.Log ("On collision");

	}

}
