using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public int coinSpawnDelay;
    public GameObject coin;
    private Vector2 wereToSpawn;
    private int spawnMax = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoinDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnCoinDelay()
    {
        wereToSpawn = new Vector2(Random.Range(-spawnMax, spawnMax), Random.Range(-spawnMax, spawnMax));
        yield return new WaitForSeconds(coinSpawnDelay);
        Instantiate(coin, wereToSpawn, transform.rotation);
        StartCoroutine(spawnCoinDelay());
    }
}
