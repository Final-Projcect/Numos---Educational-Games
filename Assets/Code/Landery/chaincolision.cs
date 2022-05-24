using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaincolision : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		chain.IsFired = false;

		if (col.tag == "Shock")
		{
			//col.GetComponent<Ball>().Split();
			Debug.Log("----------------aaaa----");
		}
	}
}
