using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
	// Cismin konumunu belirlemek icin Vector3 belirledik
	Vector3 newPosition = new Vector3(3, 2, -2);
	
    void Start()
    {
        // Nesnenin konumunu bir kez degistirir
        transform.position = newPosition;
    }
	
	void Update()
	{
		
	}
 }