using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        spawnEnemy();
    }
    public void spawnEnemy()
    {
        Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
        StartCoroutine(delay());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
