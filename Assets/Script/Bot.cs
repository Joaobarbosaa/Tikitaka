using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour 
{
	private Transform terminator;

	// Use this for initialization
	void Start () 
	{
		terminator = GameObject.FindGameObjectWithTag ("Terminator").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = transform.position;
		pos.x -= Time.deltaTime * 2;
		transform.position = pos;

		if(this.transform.position.x < terminator.position.x)
		{
			Destroy(this.gameObject);
		}

	}
}
