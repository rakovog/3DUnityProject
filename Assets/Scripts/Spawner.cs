using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private float x;
    private float z;
    private float timer;
    void Update()
    {
        x = Random.Range(250, 80);
        z = Random.Range(250, 80);
        Vector3 itemPosition = new Vector3(x, 4, z);

        timer += Time.deltaTime;

        if (timer > 5)
        {
            timer = 0;
            Instantiate(item, itemPosition, transform.rotation);

        }
    }
}
