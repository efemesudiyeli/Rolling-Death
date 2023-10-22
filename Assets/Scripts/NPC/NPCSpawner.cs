using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    [SerializeField] GameObject willSpawnPrefab;
    [SerializeField] float spawnerInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnerInterval, willSpawnPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 position = new Vector3(Random.Range(-5, 50), 7.11f, Random.Range(-20, 45));
        Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }


}
