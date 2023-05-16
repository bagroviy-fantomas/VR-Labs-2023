using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] private List<EnemySpawnPoint> enemySpawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Transform player;

    void Awake()
    {
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }
    }

    private void Start(){
        StartCoroutine(SpawnEnemy(spawnDelay));
    }

    private IEnumerator SpawnEnemy(float delay){
        yield return new WaitForSeconds(delay);
        var spawnPointIndex = Random.Range(0, enemySpawnPoints.Count);
    
        for (int i = 0; i < enemySpawnPoints.Count; i++)
        {
            if (TrySpawnEnemy(enemySpawnPoints[(i + spawnPointIndex) % enemySpawnPoints.Count])){
                break;
            }
        }
        
        StartCoroutine(SpawnEnemy(spawnDelay));
    }

    private bool TrySpawnEnemy(EnemySpawnPoint enemySpawnPoint){
        if (!enemySpawnPoint.isSeized){
            var newEnemy = Instantiate(enemyPrefab, enemySpawnPoint.transform.position, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().player = player;
            newEnemy.GetComponent<Enemy>().enemySpawnPoint = enemySpawnPoint;

            enemySpawnPoint.isSeized = true;
            var dir = player.position - newEnemy.transform.position;
            newEnemy.transform.forward = new Vector3(dir.x, newEnemy.transform.forward.y, dir.z);
        
            return true;
        }
        else{
            return false;
        }

    }
}
