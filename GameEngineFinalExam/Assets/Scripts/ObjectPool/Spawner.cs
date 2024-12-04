using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    private float[] validSpawnPositions = { -9, 9, -7, 7 };

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, 1.5f);
    }

    private void SpawnObject()
    {
        GameObject newObject = objectPool.GetObjectFromPool().gameObject;

        newObject.SetActive(true);
        newObject.transform.position = new Vector3(validSpawnPositions[Random.Range(0, 4)], 8, 0);
        newObject.GetComponent<EnemyBehavior>().BeginMoving();
    }
}
