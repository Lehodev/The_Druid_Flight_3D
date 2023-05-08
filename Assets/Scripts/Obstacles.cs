using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour
{

    public float speed = 2f;
    public float destroyOffset = 10f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -destroyOffset)
        {
            Destroy(gameObject);
        }
    }
}