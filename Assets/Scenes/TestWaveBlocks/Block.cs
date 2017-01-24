using UnityEngine;

public class Block : MonoBehaviour {

	public enum State
	{
		Idle,
		Up, 
		Down
	}

	public Transform model;

    public AudioSource tileUp;
 
    float frecuency = 5f;

    float amplitud = 0.02f;

    public float frecuencyOffset=0;

//	bool animating;

	float upTime;

    float frecuencyTime=0;

	float[] downTimes;

	float blockHeight;

	float totalHeight;

	public Sprite[] playerSprite; 

	int currentPlayer;

	State state = State.Idle;

	public SpriteRenderer playerBlockSprite;

	public float timeToIdleColor = 1.0f;

	void Awake()
	{
		if (playerBlockSprite != null) {
			var color = playerBlockSprite.color;
			color.a = 0.0f;
			playerBlockSprite.color = color;
		}
	}

	void SetPlayerSprite(int power)
	{
//		playerBlockSprite.enabled = true;
		if (playerSprite == null || playerSprite.Length == 0)
			return;

		playerBlockSprite.sprite = playerSprite [currentPlayer];

		LeanTween.cancel (playerBlockSprite.gameObject);
		LeanTween.alpha (playerBlockSprite.gameObject, 0.0f, timeToIdleColor * power).setFrom (new Vector3 (1.0f, 1.0f, 1.0f)).setEase (LeanTweenType.easeOutQuad);
	}

	public void PlayAnimation(int power, int player, BlockConfig config)
	{
		PlayAnimation (power, player, config.upTime, config.downTime, config.blockHeight);
	}

	public void PlayAnimation(int power, int player, float upTime, float[] downTimes, float blockHeight)
	{
		this.upTime = upTime;
		this.downTimes = downTimes;
		this.blockHeight = blockHeight;

		totalHeight = power * blockHeight;

		currentPlayer = player;

		SetPlayerSprite (power);

		if (tileUp != null)
        	tileUp.Play();

		StartUp ();
	}

	void StartUp()
	{
		this.state = State.Up;
	}

	void StartDown()
	{
		this.state = State.Down;
	}

	void StartIdle()
	{
		this.state = State.Idle;
//		UnsetPlayerSprite ();
	}

	void IncrementPositionY(Transform t, float y)
	{
		t.localPosition = t.localPosition + new Vector3 (0, y, 0);
	}

	void Update()
	{
        frecuencyTime += Time.deltaTime;
        if (state == State.Idle) {
            model.localPosition = new Vector3(model.localPosition.x, amplitud*Mathf.Sin(frecuency*frecuencyTime+frecuencyOffset), model.localPosition.z);
        } else if (state == State.Up) {

			float heightSpeed = totalHeight / upTime;
			IncrementPositionY (model, heightSpeed * Time.deltaTime);

			if (model.localPosition.y > totalHeight) {
				model.localPosition = new Vector3 (model.localPosition.x, totalHeight, model.localPosition.z);

				StartDown ();
			}
			
		} else if (state == State.Down) {

			var downTime = Mathf.Lerp (downTimes [1], downTimes [0], model.localPosition.y / (5 * blockHeight));

			float heightSpeed = totalHeight / downTime;

			IncrementPositionY (model, -heightSpeed * Time.deltaTime);

			if (model.localPosition.y < 0) {
				model.localPosition = new Vector3 (model.localPosition.x, 0.0f, model.localPosition.z);
				StartIdle ();
			}
				
		}

//		UpdatePlayerSprite ();
	}
}
