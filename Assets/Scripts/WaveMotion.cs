using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour {

    // Use this for initialization
    public float frecuencyOffset=0;
    public float frecuency = 2;
    public float amplitud=2;
    float time = 0;
    float startX = 0;
    float startY = 0;
    void Awake () {
        startX = transform.position.x;
        startY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
		transform.position = new Vector3(startX,startY+ amplitud * Mathf.Sin(frecuency * time + frecuencyOffset), transform.position.z);
	}
}
