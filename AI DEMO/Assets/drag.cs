using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class drag : MonoBehaviour 
{
	public static drag instance;
	public bool once=true;
	float offsetZ;
	Vector3 mouseFarPos ;
	public GameObject btn1;
	public GameObject btn2;
	public GameObject btn3;
	public GameObject btn4;
	public GameObject btn5;
	public GameObject finger;



	void Awake()
	{
		instance = this;
	}
	void Start () 
	{

	}

	void Update () 
		{
		

		float moveSpeed = 35;// SPEED OF PLAYER IF 1 WIILEXACTLY SAME FINGER MOVE SPEED INCREASE IF MORE THAN 1 (TRY BY CAHNGING THE VALUES)
		if (Input.GetMouseButtonDown(0)&&EventSystem.current.currentSelectedGameObject!=btn1 &&EventSystem.current.currentSelectedGameObject!=btn2 &&EventSystem.current.currentSelectedGameObject!=btn3 )
		{
			

			offsetZ=Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.z, Input.mousePosition.y,moveSpeed)).z-  transform.position.z;
			once = false;



		}
		if (!once) 
		{
			mouseFarPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, moveSpeed);
			mouseFarPos = Camera.main.ScreenToWorldPoint (mouseFarPos);
			mouseFarPos = new Vector3 (mouseFarPos.x, mouseFarPos.y, mouseFarPos.z);
			// CHANGE THE CONSTANT TO SCREEN WIDTH FOR X AND IEGHT FOR Y FOR COMPATIBILITY DONT ALLOW PLAYER TO OUT OF SCREEN
			transform.position=new Vector3 (Mathf.Clamp (mouseFarPos.x, 38.20768f, 38.20768f), Mathf.Clamp(mouseFarPos.y,6.002729f,6.002729f),Mathf.Clamp( mouseFarPos.z,-18.8f,33.5f));

		}
		
		if (Input.GetMouseButtonUp (0)) 
		{
			once = true;
		}
	

	}




}

	


