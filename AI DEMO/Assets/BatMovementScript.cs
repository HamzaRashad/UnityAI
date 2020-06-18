using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovementScript : MonoBehaviour 
{



	public Vector3 direction;
	public static BatMovementScript instance;
	public GameObject ball;
	public GameObject bat;

	public float batSpeed;
	bool offshot, leftshot, rightshot;











	void Awake()
	{
		instance = this;
	}


	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ball") 
		{



					
					
			if (leftshot) 
			{
				OnClickLeftShot ();
				BallMovementScript.instance.direction = new Vector3 (-1f, 0f, Random.Range(-0.5f,-0.8f));
				BallMovementScript.instance.BatHitTheBall (BallMovementScript.instance.direction, batSpeed);
				leftshot = false;
			} else if (rightshot) 
			{
				OnClickRightShot ();
				BallMovementScript.instance.direction = new Vector3 (-1f, 0f, Random.Range(0.5f,0.8f));
				BallMovementScript.instance.BatHitTheBall (BallMovementScript.instance.direction, batSpeed);
				rightshot = false;
			} else if (offshot) 
			{
				OnOffShot ();
				BallMovementScript.instance.direction = new Vector3 (-1f, 0f, Random.Range(-0.5f,-0.6f));
				BallMovementScript.instance.BatHitTheBall (BallMovementScript.instance.direction, batSpeed);
				offshot = false;
			} else 
			{
				gameObject.GetComponent<Animator> ().enabled = false;
				gameObject.GetComponent<Animator> ().enabled = true;
				gameObject.GetComponent<Animator> ().Play ("batAnim", -1, 0);
				BallMovementScript.instance.direction = new Vector3 (-1f, 0f, Random.Range(-0.5f,0.8f));
				BallMovementScript.instance.BatHitTheBall (BallMovementScript.instance.direction, batSpeed);
			}

					

				} 
			
			
		}


	public void OnClickLeftShot()
	{
		leftshot = true;


	}

	public void OnClickRightShot()
	{
		rightshot = true;

	}

	public void OnOffShot()
	{
		offshot = true;

	}

		




}
