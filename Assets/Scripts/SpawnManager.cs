using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    [SerializeField]
    private float _spawnRate = 5;
    [SerializeField]
    private float _powerupDelay = 3.0f;
    [SerializeField]
    private float _powerupDelayRange = 4.0f;
    [SerializeField]
    private GameObject[] powerups;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemyRoutine");
        StartCoroutine("SpawnPowerupRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        { 
            Vector3 enemySpawnLocation = new Vector3(Random.Range(-9.31f, 9.31f), 6.0f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, enemySpawnLocation, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnRate); 
        }
        
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 powerupSpawnLocation = new Vector3(Random.Range(-9.0f, 9.0f), 7.0f, 0);
            float waitTime = Random.Range(_powerupDelay, _powerupDelay + _powerupDelayRange);
            int powerupSelection = Random.Range(0, 2);
            GameObject newTripleShotPowerup = Instantiate(powerups[powerupSelection], powerupSpawnLocation, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
