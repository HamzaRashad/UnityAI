using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour 
{
	public Animator anim;
	public static AiMovement instance;
	public BatMovementScript playerBat;

	public float AITimeGap;
	public float AIPaddleSpeed;
	private float tc;
	private float reqZ;
	public bool isActive;
	public int aiCounter = 0;
	public GameObject ball;





	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		

		aiCounter = 0;





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

//		



	}
		
	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ball") 
		{
			if (playerBat.transform.position.z < 0) 
			{
				PlayRightShot ();
			} 
			if (playerBat.transform.position.z > 0) 
			{
				PlayLeftShot ();
			}

		}
	}

	public void PlayRightShot()
	{
		BallMovementScript.instance.direction = new Vector3 (1f, 0f, Random.Range(0.8f,2f));
		BatMovementScript.instance.batSpeed = Random.Range (60, 100);
		BallMovementScript.instance.AiHitTheBall (BallMovementScript.instance.direction, BatMovementScript.instance.batSpeed = Random.Range (60, 100));
	}

	public void PlayLeftShot()
	{
		BallMovementScript.instance.direction = new Vector3 (1f, 0f, Random.Range(-0.8f,-2f));
		BallMovementScript.instance.AiHitTheBall (BallMovementScript.instance.direction, BatMovementScript.instance.batSpeed = Random.Range (60, 100));
	}



}
