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
    [SerializeField] private float scatter;
    [SerializeField] private float deathForce;
    [SerializeField] private float deathDelay;

    void Start()
    {
        StartCoroutine(Shoot(GetCd()));
    }

    private IEnumerator Shoot(float delay){
        yield return new WaitForSeconds(delay);
        var newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity,EnemySpawner.Instance.Bullets);
        newBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * (player.position * UnityEngine.Random.Range(1 - scatter, 1 + scatter) - bulletSpawnPoint.position).normalized;
        StartCoroutine(Shoot(GetCd()));
    }

    private float GetCd(){
        return cd * UnityEngine.Random.Range(0.8f, 1.2f);
    }

    public void TakeDamage(){
        Death();
        Destroy(gameObject);
    }

    private void OnDestroy(){
        enemySpawnPoint.isSeized = false;
        StopAllCoroutines();
        EnemySpawner.Instance.AddScore();
    }

    private void Death(){

        var children = new List<Transform>();
        for (int i = 0; i < transform.childCount; ++i)
            children.Add(transform.GetChild(i));
        
        foreach (Transform child in children) {
            child.parent = null;
            child.gameObject.AddComponent<MeshCollider>().convex = true;
            var rb = child.gameObject.AddComponent<Rigidbody>();
            Vector3 dir = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f),UnityEngine.Random.Range(-1f, 1f));
            rb.AddForce(dir * deathForce, ForceMode.Impulse);
            Destroy(child.gameObject, deathDelay);
        }
    }
}
