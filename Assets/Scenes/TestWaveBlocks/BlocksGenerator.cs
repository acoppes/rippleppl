using UnityEngine;

public class BlocksGenerator : MonoBehaviour {

	public GameObject[] blockPrefabs;

	public int rows;
	public int cols;

	public Vector2 separations;

	public GameObject startPositionReference;

//	public G

	int current;

	void Awake()
	{
		Vector3 position = startPositionReference.transform.position;

		for (int j = 0; j < cols; j++) {
			for (int i = 0; i < rows; i++) {
				var blockPrefab = blockPrefabs [current];
				var block = GameObject.Instantiate (blockPrefab);
                var code = block.GetComponent<Block>();
                code.frecuencyOffset = j+i;
				block.transform.SetParent (this.transform);
				block.transform.position = position + new Vector3 (j * separations.x, i * separations.y, i);
				current = (current + 1) % blockPrefabs.Length;
			}
		}
	}

}
