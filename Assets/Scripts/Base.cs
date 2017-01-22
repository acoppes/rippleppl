using UnityEngine;

public class Base : MonoBehaviour {
    public enum State
    {
        Idle,
        Shake,
        Down
    }

    public HealthBarModel healthBar;
    public float totalHeight = 2f;

	Health health = new Health();

	public GameController gameLogic;
    public Transform model;

    float upTime;

	public float downAcceleration = 0.2f;

    float shakeTime = 0;
    float shakeTotalTime = 0.5f;

    float heightSpeed=0;
    float localX;
    float lastY;
    float baseY;

    State state = State.Idle;

	public int player;

	void Awake()
	{
		health.total = gameLogic.data.playerHealth;
		health.current = health.total;
        baseY = model.localPosition.y;
        SetHeight(model, healthToHeight());
        localX = model.localPosition.x;
	}

	public void ReceiveDamage(int wavePower)
	{
		if (health.IsDead ())
			return;
        gameLogic.shakeCamera(0.2f);
		health.Damage (wavePower);
		healthBar.SetHealth (health.GetFactor ());

		if (health.IsDead ())
			gameLogic.OnBaseDeath (this);

        StartShake();
    }
    void Update()
    {
      
        if (state == State.Idle)
        {
          
        }
        else if (state == State.Shake)
        {
            shakeTime -= Time.deltaTime;
            Shake(model);
            if (shakeTime<0)
            {
                heightSpeed = 0;
                StartDown();
                model.localPosition = new Vector3(localX, lastY, 0f);
            }

        }
        else if (state == State.Down)
        {

			heightSpeed += downAcceleration * Time.deltaTime;

            SetHeight(model, -heightSpeed * Time.deltaTime);

            if (model.localPosition.y <= baseY+healthToHeight())
            {
                model.localPosition=new Vector3(model.localPosition.x, baseY + healthToHeight(), 0f);
                StartIdle();
            }

        }
    }

    void StartShake()
    {
        lastY = model.localPosition.y;
        shakeTime = shakeTotalTime;
        this.state = State.Shake;
    }

    void StartDown()
    {
        this.state = State.Down;
    }

    void StartIdle()
    {
        this.state = State.Idle;
    }

    void SetHeight(Transform t, float y)
    {
        t.localPosition = t.localPosition + new Vector3(0, y, 0);
    }
    void Shake(Transform t)
    {
        t.localPosition =  new Vector3(localX+Random.Range(-0.5f,0.5f)*Time.deltaTime, lastY+Random.Range(-0.5f, 0.5f)*Time.deltaTime, 0);
    }
    float healthToHeight()
    {
        return health.current*totalHeight/health.total;
    }  
}
