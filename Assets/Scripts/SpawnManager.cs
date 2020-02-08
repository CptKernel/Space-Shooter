using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Spawn game objects every 5 seconds.
    // Create a coroutine of type IEnumerator -- Yield Events
    // Use while loop 

    IEnumerator SpawnRoutine()
    {
        //while loop (infinite)
            // Instantiate enemy prefab
            // yield wait for 5 seconds
        while (true)
        { 
            Vector3 enemySpawnLocation = new Vector3(Random.Range(-9.31f, 9.31f), 6.0f, 0);
            Instantiate(_enemyPrefab, enemySpawnLocation, Quaternion.identity);
            yield return new WaitForSeconds(5); 
        }
        
    }
}
