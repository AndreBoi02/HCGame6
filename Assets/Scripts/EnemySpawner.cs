using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] private GameObject[] enemiesPrefabs;
    [SerializeField] private ObjectPooling objectPooling;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 10;
    [SerializeField] private float enemiesPerSecond = .5f;
    [SerializeField] private float timeBetweenWaves = 5;
    [SerializeField] private float difficultyScalingFactor = .75f;

    [SerializeField] private int currenWave = 1;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlives;
    [SerializeField] private int enemiesLeft2Spawn;
    [SerializeField] private bool isSpawing = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(OnEnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawing) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeft2Spawn > 0)
        {
            SpawnEnemy();
            enemiesLeft2Spawn--;
            enemiesAlives++;
            timeSinceLastSpawn = 0;
        }

        if (enemiesAlives == 0 && enemiesLeft2Spawn == 0)
        {
            EndWave();
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawing = true;
        enemiesLeft2Spawn = EnemiesPerWave();
    }
    private void EndWave()
    {
        isSpawing = false;
        timeSinceLastSpawn = 0;
        currenWave++;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        GameObject prefab2Spawn = objectPooling.RequestObject();
        prefab2Spawn.transform.position = LevelManager.main.startPoint.position;
    }

    private void OnEnemyDestroyed()
    {
        enemiesAlives--;
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currenWave, difficultyScalingFactor));
    }

}
