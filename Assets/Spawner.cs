using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject downObstacle;
    public GameObject upObstacle;

    public float frequence;
    public float maxHeight;
    public float playerSize;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawn()
    {
        while (true)
        {
            float rnd = Random.Range(1, maxHeight - 1);
            Vector3 rescaleDown = downObstacle.transform.localScale;
            rescaleDown.y = rnd;
            downObstacle.transform.localScale = rescaleDown;

            Vector3 rescaleUp = upObstacle.transform.localScale;
            rescaleUp.y = maxHeight - rescaleDown.y - (playerSize * (float) 1.5);
            upObstacle.transform.localScale = rescaleUp;

            Vector3 spawnPositionDown = new Vector3(6, (rescaleDown.y / 2) + (float) 0.01, 0);
            Vector3 spawnPositionUp = new Vector3(6, maxHeight - (rescaleUp.y / 2), 0);

            Destroy(Instantiate(downObstacle, spawnPositionDown, Quaternion.identity), 10f);
            Destroy(Instantiate(upObstacle, spawnPositionUp, Quaternion.identity), 10f);

            yield return new WaitForSeconds(frequence);
        }
    }
}