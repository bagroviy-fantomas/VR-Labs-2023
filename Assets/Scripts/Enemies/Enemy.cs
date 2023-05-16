using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    [NonSerialized] public Transform player;
    [NonSerialized] public EnemySpawnPoint enemySpawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float cd;
    [SerializeField] private float bulletSpeed;

    void Start()
    {
        StartCoroutine(Shoot(GetCd()));
    }

    private IEnumerator Shoot(float delay){
        yield return new WaitForSeconds(delay);
        var newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * (player.position - bulletSpawnPoint.position).normalized;
        StartCoroutine(Shoot(GetCd()));
    }

    private float GetCd(){
        return cd;
    }

    public void TakeDamage(){
        Destroy(gameObject);
    }

    private void OnDestroy(){
        enemySpawnPoint.isSeized = false;
    }
}
