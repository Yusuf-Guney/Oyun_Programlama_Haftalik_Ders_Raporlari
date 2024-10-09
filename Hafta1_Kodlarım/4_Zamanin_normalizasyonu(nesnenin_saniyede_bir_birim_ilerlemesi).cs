using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script: MonoBehaviour
{
	//Nesnenin saniyede kaç birim ilerleyeceğini belirleyen hız
	public float speed = 1f;

	void Start()
	{
			
	}
	void Update(){

	// Nesnenin zaman normalizsyonuna göre sağa doğru ilerlemesini sağlar
	transform.position += Vector3.right speed* Time.deltaTime;

	}
}
