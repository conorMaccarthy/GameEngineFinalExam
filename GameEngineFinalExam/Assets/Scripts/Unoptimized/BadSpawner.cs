using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSpawner : MonoBehaviour
{
    private float[] validSpawnPositions = { -9, 9, -7, 7 };

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject decoyPrefab;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, 0.1f);
    }

    private void SpawnObject()
    {
        GameObject newObject = Instantiate(enemyPrefab);
        newObject.transform.position = new Vector3(validSpawnPositions[Random.Range(0, 4)], 8, 0);
        newObject.GetComponent<BadEnemyBehavior>().BeginMoving();
    }
}
