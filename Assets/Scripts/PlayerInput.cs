using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    bool moved;
    bool moveUp;
    bool moveDown;

    public string verticalAxis = "Vertical1";

    public string moveKey = "MoveKey1";

    public string chargeWave = "ChargeWave1";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveDown = false;
        moveUp = false;

        float axisY = Input.GetAxis(verticalAxis)+ Input.GetAxis(moveKey);
        
        if (moved)
        {
            if (axisY == 0)
            {
                moved = false;
            }
        }
        else
        {
            if (axisY < 0)
            {
                moveUp = true;
                moved = true;
            }
            else if (axisY > 0)
            {
                moveDown = true;
                moved = true;
            }
        }
    }
    public bool MoveUp() {
        return moveUp;
    }
    public bool MoveDown()
    {
        return moveDown;
    }
    public bool Charging()
    {
        return Input.GetButton(chargeWave);
    }
    public bool Release()
    {
        return Input.GetButtonUp(chargeWave);
    }
}
