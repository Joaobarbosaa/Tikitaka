using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	[SerializeField]
	private Transform player1, player2;

	private Vector3 pos, next, follow, limit;
	private int pass, angle;
	private float rotate;
	private bool move;
	// Use this for initialization
	void Start ()
	{
		pos = next = transform.position;
		follow = player1.position;
		limit = new Vector3 (1, 0.7f, 0);
		rotate = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(pass % 2 == 0)
		{
			if(Input.GetKeyDown(KeyCode.Space) && !move)
			{
				move = true;
				pass++;
				rotate = 50;
					follow = player2.position;
			}
		}

		if (pass % 2 == 1)
		{
			if(Input.GetKeyDown (KeyCode.P) && !move)
			{
				move = true;
				pass++;
				rotate = 50;
					follow = player1.position;
			}
		}

		if(pass % 2 == 0)
			next = follow + new Vector3(limit.x, limit.y);
		else
			next = follow + new Vector3(limit.x, -limit.y);


		pos = Vector3.Lerp (pos, next, 0.1f);

		if (pos == next)
			move = false;

		rotate = Mathf.Lerp(rotate, 10, 0.1f);
		transform.Rotate(0, 0, rotate);

		angle += 2;

		float moveX = Mathf.Cos (angle * (Mathf.PI / 180));

		transform.position = new Vector3(pos.x + (moveX / 10 + 0.1f), pos.y);
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.CompareTag("Zidane"))
		{
			Application.LoadLevel("Lose");
		}
	}
}
