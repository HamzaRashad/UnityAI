using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour 
{
	public Animator anim;
	public static AiMovement instance;
	public float aiBatsmanReachLimitMax;
	public float aiBatsmanReachLimitMin;
	public float AITimeGap;
	public float AIPaddleSpeed;
	private float tc;
	private float reqZ;
	public bool isActive;
	public int aiCounter = 0;
	public GameObject ball;
	public int aIplayModes = 1;
	public int aImaxCounter = 0;




	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		isActive = true;
		anim = gameObject.GetComponent<Animator>();
		anim.enabled = false;
		aiCounter = 0;
		aIplayModes = 1;
		aImaxCounter = 0;




	}

	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3(Mathf.Clamp(transform.position.x,transform.position.x,transform.position.x),transform.position.y,Mathf.Clamp(transform.position.z,-25.2f,27.8f));
		if (isActive) 
		{
			tc = tc + Time.deltaTime;
			if (tc >= AITimeGap) 
			{
				tc = tc - AITimeGap;
				reqZ = ball.transform.position.z;
			}
			if (transform.position.z < reqZ) 
			{
				this.transform.position += new Vector3 (0f, 0f, AIPaddleSpeed * Time.deltaTime);
			}
			if (transform.position.z > reqZ) 
			{
				this.transform.position -= new Vector3 (0f, 0f, AIPaddleSpeed * Time.deltaTime);
			}

		}





	}


	void TurnOff()
	{

		BatMovementScript.instance.counter = 0;
		BatMovementScript.instance.maxCounter = 0;
	}

	public void resetAiParams()
	{
		transform.position = new Vector3 (-1.05f, 0.265f, -0.09f);
		aiCounter = 0;
		aImaxCounter = 0;
		isActive = true;
		aIplayModes = 1;
	}

	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ball") 
		{
			BallMovementScript.instance.direction = new Vector3 (1f, 0f, Random.Range(-0.5f,0.8f));
			BallMovementScript.instance.AiHitTheBall (BallMovementScript.instance.direction, BatMovementScript.instance.batSpeed);
		}
	}
}
