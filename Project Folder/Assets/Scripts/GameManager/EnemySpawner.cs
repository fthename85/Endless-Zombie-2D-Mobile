using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{   //enemies
    public GameObject[] weakEnemyPrefab,DamageTextUI;
    GameObject[] EnemiesAlive,EnemySpawnerLocation;
    Transform spawnergameObject;
    //waves

    int WeakEnemySpawned = 0;
    //Spawner

    int waveinclementForWeakEnemy = 0,
    RandomWeakEnemyInclement = 0,
    numberOfWeakEnemyToSpawn = 2,
    AllowedWeakEnemy = 1;
    
    //temporary
    
    void start()
    {
      AllowedWeakEnemy = 0;
    }
    void Update()
    {
        if(EnemySpawnerLocation == null)
        {
            EnemySpawnerLocation = GameObject.FindGameObjectsWithTag("EnemySpawner");
        }
        
        EnemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        SpawnAtRandomPosition(EnemiesAlive.Length);

        if(WeakEnemySpawned >= numberOfWeakEnemyToSpawn)
        {
            CancelInvoke("WeakSpawner");
            WeakEnemySpawned = 0;
        }
    }
    void SpawnAtRandomPosition(int EnemiesStillAlive)
    {
        if(EnemiesStillAlive <= 0)
        {
            RandomWeakEnemyInclement++;
            waveinclementForWeakEnemy++;
            if(waveinclementForWeakEnemy >= 2)
            {
                numberOfWeakEnemyToSpawn += 2;
                waveinclementForWeakEnemy = 0;
            }
            if(RandomWeakEnemyInclement >= 3)
            {
                if(AllowedWeakEnemy < weakEnemyPrefab.Length)
                {AllowedWeakEnemy++;}
                RandomWeakEnemyInclement = 0;

            }
            InvokeRepeating("WeakSpawner", 0.0f, 1.0f);
        }
    }
    void WeakSpawner()
    {
        if (WeakEnemySpawned < numberOfWeakEnemyToSpawn)
        {
            spawnergameObject = EnemySpawnerLocation[Random.Range(0,EnemySpawnerLocation.Length - 1)].transform;
            Instantiate(weakEnemyPrefab[Random.Range(0,AllowedWeakEnemy)], spawnergameObject.position, Quaternion.Euler(0,0,0));
            WeakEnemySpawned++;   
        }
    }
}