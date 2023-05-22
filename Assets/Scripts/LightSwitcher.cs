using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("LeverHandle"))
		{
			Destroy(other.transform.parent.gameObject);
			EnemySpawner.Instance.StartGame();
		}
	}
}
