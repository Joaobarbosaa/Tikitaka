using UnityEngine;
using System.Collections;

public class MovimentationGround : MonoBehaviour 
{
	[SerializeField]
	float speedx;

	// Use this for initialization
	void Start () 
	{

	}
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(speedx, 0, 0);
		
		
		if(this.transform.position.x < -25)
		{
			this.transform.position = new Vector3(34,0.9f,0);
		}

	}
}
