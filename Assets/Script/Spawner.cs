using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{

	[SerializeField]
	GameObject[] spawners;
	
	[SerializeField]
	string[] Paths;
	
	[SerializeField]
	float Interval;
	
	[SerializeField]
	int MaxObjects;

	float FirstInterval;

	GameObject NewObject, ActualObject, LastObject, ActualSpawner, LastSpawner, NextSpawner, zidane;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine(Spawn());
		FirstInterval = Interval;
	}

	protected void ShuffleSpawner()
	{ 
		ActualSpawner = spawners[GetRandomInt(0, spawners.Length)];
		
		if(LastSpawner == ActualSpawner)
		{
			ShuffleSpawner();
		}
	}

	int GetRandomInt(int min, int max)
	{
		return Mathf.RoundToInt(Random.RandomRange(min, max));
	}

	protected IEnumerator Spawn()
	{
		yield return new WaitForSeconds(Interval);
		
		if(MaxObjects <= 0)
		{
			MaxObjects = GetRandomInt(1, spawners.Length - 1);
		}
		
		
		for (int i = 0; i < MaxObjects; i++)
		{
			ShuffleSpawner();
			int side = GetRandomInt(0, Paths.Length);

			NewObject = (GameObject)Instantiate(Resources.Load("Prefabs/" + Paths[side]));


			LastSpawner = ActualSpawner;
		}

		
		//Interval = FirstInterval + PlayerPrefs.GetInt("Score") * 0.5f;
		Interval = PlayerPrefs.GetInt("Score")  - Interval/2;
		if (Interval <= 0)
			Interval = 1;
		print(PlayerPrefs.GetInt("Score")  - Interval);

		StartCoroutine(Spawn());
	}

	void Update()
	{
	}
	
}
