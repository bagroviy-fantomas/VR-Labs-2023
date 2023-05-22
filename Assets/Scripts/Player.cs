using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public static Player Instance;
    
    [SerializeField] private int hp;
    private int currentHp;
    [SerializeField] private GameObject leverPref;
    [SerializeField] private Transform leverTransform;
    private AudioSource damageSound;

    void Awake()
    {
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }
    }

    public void Start() 
    {
        Instantiate(leverPref, leverTransform.position, Quaternion.identity);
        ResetHP();
        damageSound = GetComponent<AudioSource>();
    }

    public void TakeDamage(){
        currentHp--;
        damageSound.Play();
        Debug.Log(currentHp);
        if (currentHp <= 0 ){
            Instantiate(leverPref, leverTransform.position, Quaternion.identity);
            EnemySpawner.Instance.StopGame();
            EnemySpawner.Instance.ClearEnemies();
        }
    }

    public void ResetHP(){
        currentHp = hp;
    }

    public int GetCurrentHP(){
        return currentHp;
    }
}
