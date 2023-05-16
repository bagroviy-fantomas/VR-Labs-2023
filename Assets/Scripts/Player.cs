using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private int hp;

    void Start()
    {
        
    }

    public void TakeDamage(){
        hp--;
        Debug.Log(hp);
        if (hp <= 0 ){
            Debug.Log("u lose((");
        }
    }
}
