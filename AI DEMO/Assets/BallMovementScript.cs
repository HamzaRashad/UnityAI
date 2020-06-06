using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovementScript : MonoBehaviour 
{	
	public static BallMovementScript instance;

	public Rigidbody rb;
	public float ballSpeed;
	public  Vector3 direction;
	public GameObject ball;
	public bool isAiscore;
	public bool isPlayerscore;
	public bool isstart;

	public Text aiOut;
	public Text playerOut;
	public int outAi;
	public int outPlayer;
	bool isGameOver;
	public Text outText;





	// Use this for initialization

	void Awake()
	{
		instance = this;
	}

	void Start () 
	{
		this.direction = new Vector3 (1f, 0f, 0f);
		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame

	void Update()
	{
		if (!isGameOver) 
		{
			this.transform.position += new Vector3 (direction.x * ballSpeed * Time.deltaTime, 0f, direction.z * ballSpeed * Time.deltaTime);

		}
	
	}


	public void BatHitTheBall(Vector3 hitDirection, float batSpeed)
	{



		float hitSpeed = ballSpeed;							//(ballSpeed / 2) + batSpeed;

		rb.AddForce (direction * hitSpeed);
		rb.constraints = RigidbodyConstraints.FreezePositionY;

	}

	public void AiHitTheBall(Vector3 hitDirection, float batSpeed)
	{



		float hitSpeed = ballSpeed;									//(ballSpeed / 2) + batSpeed;
		rb.AddForce (direction * hitSpeed);
		rb.constraints = RigidbodyConstraints.FreezePositionY;



	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "bounds") 
		{
			Vector3 normal = col.contacts [0].normal;
			direction = Vector3.Reflect (direction, normal);
			ballSpeed = 50f;
		}

		if (col.gameObject.tag == "aiwickets") 
		{
			outAi += 1;
			aiOut.text = "AI OUT: " + outAi;
			outText.gameObject.SetActive (true);
			isGameOver = true;
			rb.isKinematic = true;
			outText.text = "AI OUT! ";
			Invoke ("reset", 3f);
		}

		if (col.gameObject.tag == "playerwickets") 
		{
			outPlayer += 1;
			aiOut.text = "PLAYER OUT: " + outPlayer;
			isGameOver = true;
			outText.gameObject.SetActive (true);
			rb.isKinematic = true;
			outText.text = "PLAYER OUT! ";
			Invoke ("reset", 3f);
		}
	}

	void reset()
	{
		ball.transform.position = new Vector3 (0, 3.41f, 0);
		rb.isKinematic = false;
		isGameOver = false;
		outText.gameObject.SetActive (false);
		this.direction = new Vector3 (1f, 3.41f, 0f);


	}






}
