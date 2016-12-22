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
	private GameObject blurbReal;

	public GameObject blurbPrefab;




	void Start () 
	{
		step = 5.0f;
		blurbActivate = false;
		DrawSightRays ();
	}
	





	void Update () 
	{
		FindDistance ();

		if (blurbActivate)
		{
			transform.rotation = Quaternion.LookRotation ((blurbReal.transform.position - playerPos));
			transform.position = Vector3.MoveTowards (transform.position, blurbReal.transform.position, step * Time.deltaTime);
			FindPlayer ();

			if (playerPos == blurbReal.transform.position)
			{
				Destroy (blurbReal);
			}
		}
	}






	void FindCursor ()
	{
		float mousePosX = Input.mousePosition.x / Screen.width * 13.5f;
		float mousePosY = Input.mousePosition.y / Screen.height * 10.0f;
		mousePos = new Vector3 (mousePosX, mousePosY, X_POS);
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
		FindCursor ();
		FindPlayer ();

		if (Input.GetMouseButtonDown (0))
		{
			if (blurbReal)
			{
				Destroy (blurbReal);
			}

			distance = Vector3.Distance (playerPos, mousePos);
			blurbReal = Instantiate (blurbPrefab, mousePos, Quaternion.identity) as GameObject;
			blurbActivate = true;

			Debug.Log ("Distance From Mouse To Player = " + distance);
		}
	}






	void DrawSightRays ()
	{
		rightSight.origin = leftSight.origin = playerPos;

		rightSight.direction = new Vector2 (1.0f, (Mathf.PI / 4.0f));
		leftSight.direction = new Vector2 (1.0f, Mathf.PI / 4.0f);

		Debug.Log ("Right Sight: Direction " + rightSight.direction + " Left Sight Direction: " + leftSight.direction);
	}
}
