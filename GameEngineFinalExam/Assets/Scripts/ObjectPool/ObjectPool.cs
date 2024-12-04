using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int poolSize = 4;
    [SerializeField] private PooledObject enemyPrefab;
    [SerializeField] private PooledObject decoyPrefab;

    private Queue<PooledObject> objectStack;

    private void Start()
    {
        objectStack = new Queue<PooledObject>();

        PooledObject newPooledObject;

        for (int i = 0; i < poolSize; i++)
        {
            newPooledObject = Instantiate(enemyPrefab);
            newPooledObject.pool = this;
            newPooledObject.gameObject.SetActive(false);
            objectStack.Enqueue(newPooledObject);
        }

        newPooledObject = Instantiate(decoyPrefab);
        newPooledObject.pool = this;
        newPooledObject.gameObject.SetActive(false);
        objectStack.Enqueue(newPooledObject);
    }

    public PooledObject GetObjectFromPool()
    {
        if (objectStack.Count == 0)
        {
            PooledObject newPooledObject = Instantiate(enemyPrefab);
            newPooledObject.pool = this;
            return newPooledObject;
        }

        PooledObject nextObject = objectStack.Dequeue();
        nextObject.gameObject.SetActive(true);
        return nextObject;
    }

    public void ReturnPooledObject(PooledObject pooledObject)
    {
        objectStack.Enqueue(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
