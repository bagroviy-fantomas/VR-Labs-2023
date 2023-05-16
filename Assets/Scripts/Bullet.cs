using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string targetTag;
    
    private void OnTriggerEnter(Collider other){
        if (other.transform.CompareTag(targetTag)){
            other.GetComponent<ICharacter>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
