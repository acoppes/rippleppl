using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour {


    //Shake Logic
    float shakeTime = 0;
    float totalShakeTime = 0;
    float maxShakeX = 0;
    float maxShakeY = 0;
    float shakeInterval;
    float lastShake = 0;
    bool inRestPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            lastShake += Time.deltaTime;
            if (lastShake >= shakeInterval)
            {
                lastShake = 0;
                float s = shakeTime / totalShakeTime;

                float x= maxShakeX * s * 2 - Random.value * maxShakeX;
                float y= maxShakeY * s * 2 - Random.value * maxShakeY;
                this.gameObject.transform.position = new Vector3(x, y, -10);
            }
        }else
        {
            if (!inRestPos)
            {
                inRestPos = true;
                this.gameObject.transform.position = new Vector3(0, 0, -10);
            }
        }
        
    }

    public void shake(float time, float maxX = 10, float maxY = 10, float shakeInterval = 0.1f)
    {
        shakeTime = totalShakeTime = time;
        maxShakeX = maxX;
        maxShakeY = maxY;
        inRestPos = false;
        this.shakeInterval = shakeInterval;
    }
}
