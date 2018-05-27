using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Spawner : MonoBehaviour
{

    public GameObject basicEnemyPrefab;
    public Transform spawnLocation;

    private void Start()
    {
        GameObject.Instantiate(basicEnemyPrefab, spawnLocation);
    }
    private void Update()
    {
    }
}
