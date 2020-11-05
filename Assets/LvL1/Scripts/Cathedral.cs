using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cathedral : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        while (true)
        {
            Vector3 position = transform.position;
            position.x += 0.1f;
            transform.position = position;
            yield return new WaitForSeconds(0.05f);
            position = transform.position;
            position.x -= 0.1f;
            transform.position = position;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
