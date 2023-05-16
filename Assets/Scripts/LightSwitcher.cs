using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    [SerializeField] private Light light;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private GameObject screamer;
    [SerializeField] private bool isEnable;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("LeverHandle"))
		{
			light.enabled = isEnable;
			if (!isEnable){
				audioSource.Play();
				screamer.SetActive(true);
			}
			else{
				audioSource.Pause();
				screamer.SetActive(false);
			}
		}
	}
}
