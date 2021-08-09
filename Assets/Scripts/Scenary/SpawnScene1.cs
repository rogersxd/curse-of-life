using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScene1 : MonoBehaviour
{
    public GameObject summonPreFab;
    private float spawnTimeRight = 1f;
    private float spawnTimeLeft = 2f;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimeRight = Time.time + spawnTimeRight;
        spawnTimeLeft = Time.time + spawnTimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTimeRight) {
            for(int i = 0; i < 3; i++) {
                Instantiate(
                    summonPreFab,
                    new Vector3(88, 0, 0), 
                    Quaternion.identity
                );
            }

            spawnTimeRight += spawnTimeRight;
            
        }

        if (Time.time > spawnTimeLeft) {
            for(int i = 0; i < 3; i++) {
                Instantiate(
                    summonPreFab,
                    new Vector3(-6, 0, 0), 
                    Quaternion.identity
                );
            }

            spawnTimeLeft += spawnTimeLeft;
        }
    }
}
