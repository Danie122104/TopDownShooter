using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletController : MonoBehaviour
{
    private float moveSpeed = 10;

    public float bulletDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyDelay());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }
    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(bulletDelay);
        Destroy(gameObject);
    }
}
