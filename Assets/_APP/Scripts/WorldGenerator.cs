using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public Transform floorTransform;
    public Transform playerTransform;

    [Header("Hazzards")]
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 10f;
    public float spawnDistance = 150f;
    public GameObject[] hazzardsPool;

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        while (true)
        {
            

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            GenerateHazzard();
        }
    }

    void GenerateHazzard()
    {
        int prefabIndex = Random.Range(0, hazzardsPool.Length);
        GameObject newHazzard = Instantiate(hazzardsPool[prefabIndex]) as GameObject;

        SpaceShipMovement spaceShip = playerTransform.GetComponent<SpaceShipMovement>();

        newHazzard.transform.position = new Vector3(spaceShip.currentRail.x, playerTransform.position.y, playerTransform.position.z + spawnDistance);
        newHazzard.SetActive(true);
    }


}
