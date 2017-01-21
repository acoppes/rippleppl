using UnityEngine;

public class BlocksGenerator : MonoBehaviour {

	public GameObject blockPrefab;

	public int rows;
	public int cols;

	public Vector2 separations;

	public GameObject startPositionReference;

	void Awake()
	{
		Vector3 position = startPositionReference.transform.position;

		for (int j = 0; j < cols; j++) {
			for (int i = 0; i < rows; i++) {
				var block = GameObject.Instantiate (blockPrefab);
				block.transform.SetParent (this.transform);
				block.transform.position = position + new Vector3 (j * separations.x, i * separations.y, i);
			}
		}
	}

}
