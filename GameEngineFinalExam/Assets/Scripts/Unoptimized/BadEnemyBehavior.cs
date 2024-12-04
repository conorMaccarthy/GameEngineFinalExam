using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnemyBehavior : MonoBehaviour
{
    public void BeginMoving()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        Vector3 startPosition = transform.position;

        Vector3 endPosition;

        if (transform.position.x > 0) endPosition = new Vector3(-9, -4.5f, transform.position.z);
        else endPosition = new Vector3(9, -4.5f, transform.position.z);

        float timeElapsed = 0;
        float travelTime = 4;

        while (timeElapsed < travelTime)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / travelTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        if (gameObject.tag == "Enemy") UIManager.instance.UpdateLives(-1);
        Deactivate();
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateSequence());
    }

    IEnumerator DeactivateSequence()
    {
        yield return null;
        Destroy(gameObject);
    }
}
