using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovementScript : MonoBehaviour 
{


	public Animator anim;
	public Vector3 direction;
	public static BatMovementScript instance;
	public GameObject ball;
	public GameObject bat;
	public float batsmanReachLimitMax;
	public float batsmanReachLimitMin;
	public float batSpeed;
	public int counter = 0;
	public bool isLeftClicked;
	public bool isRightClicked;
	public bool shotsOn;
	public int maxCounter = 0;
	public Sprite [] unselectLevelSprite;	
	public Sprite [] selectLevelSprite;
	public GameObject [] shots_btn;









	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator>();
		anim.enabled = false;
		counter = 0;
		isLeftClicked = false;
		isRightClicked = false;
		shotsOn = false;
		maxCounter = 0;


	}

	// Update is called once per frame
	void Update () 
	{	



	}


	public void OnClickLeftShot()
	{
		isLeftClicked = true;
		isRightClicked = false;
		shots_btn [0].GetComponent<UnityEngine.UI.Image> ().sprite = selectLevelSprite[0];
		shots_btn [1].GetComponent<UnityEngine.UI.Image> ().sprite = unselectLevelSprite[1];
		shotsOn = true;
		batsmanReachLimitMin = 0.695f;
		batsmanReachLimitMax = 0.7f;






	}
	public void OnClickOffShot()
	{
		shots_btn [1].GetComponent<UnityEngine.UI.Image> ().sprite = selectLevelSprite[1];
		shots_btn [0].GetComponent<UnityEngine.UI.Image> ().sprite = unselectLevelSprite[0];
		isRightClicked = true;
		isLeftClicked = false;
		shotsOn = true;
		batsmanReachLimitMin = 0.576f;
		batsmanReachLimitMax = 0.864f;




	}

	public void resetPlayerParams()
	{
		transform.position = new Vector3 (0.952f, 0.204f, 0.115f);
		counter = 0;
		maxCounter = 0;
		isLeftClicked = false;
		isRightClicked = false;
		shotsOn = false;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ball") 
		{
			

					counter = counter + 1;
					gameObject.GetComponent<Animator> ().enabled = false;
					gameObject.GetComponent<Animator> ().enabled = true;
					gameObject.GetComponent<Animator> ().Play ("batAnim", -1, 0);
					BallMovementScript.instance.direction = new Vector3 (-1f, 0f, Random.Range(-0.5f,0.8f));
					BallMovementScript.instance.BatHitTheBall (BallMovementScript.instance.direction, batSpeed);
								}

				}

}
