using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour 
{
	private const float X_POS = 0.0f;

	
	private float distance;
	private Vector3 mousePos;
	private Vector3 playerPos;
	private bool blurbActivate;
	private float step;
	private Ray2D rightSight;
	private Ray2D leftSight;


	public GameObject blurb;



	void Start () 
	{
		step = 5.0f;
		blurbActivate = false;
	}
	





	void Update () 
	{
		FindDistance ();

		if (blurbActivate)
		{
			transform.position = Vector3.MoveTowards (transform.position, mousePos, step * Time.deltaTime);
		}
	}






	void FindCursor ()
	{
		float mousePosX = Input.mousePosition.x / Screen.width * 13.5f;
		float mousePosY = Input.mousePosition.y / Screen.height * 10.0f;
		mousePos = new Vector3 (mousePosX, mousePosY, X_POS);

		Debug.Log ("Mouse-X = " + mousePosX + " Mouse-Y = " + mousePosY);
	}






	void FindPlayer ()
	{
		float playerPosX = this.gameObject.transform.position.x;
		float playerPosY = this.gameObject.transform.position.y;
		playerPos = new Vector3 (playerPosX, playerPosY, X_POS);

		Debug.Log ("Player-X = " + playerPosX + " Player-Y = " + playerPosY);
	}






	void FindDistance ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			FindCursor ();
			FindPlayer ();

			distance = Vector3.Distance (playerPos, mousePos);
			Instantiate (blurb, mousePos, Quaternion.identity);
			blurbActivate = true;

			Debug.Log ("Distance From Mouse To Player = " + distance);
		}
	}
}
