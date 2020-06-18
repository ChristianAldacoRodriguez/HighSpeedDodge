using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFloorController : MonoBehaviour
{

    public Transform[] floors;
    public int currentIndex = 0;

    public float distanceToMove = 1000f;
    private float playerDistance = 0f;
    private int timesRepeated = 1;

    public void AddPlayerDistance(float delta)
    {
        playerDistance += delta;
    }

    private void Update()
    {
        if(playerDistance > 0f)
        {

            float division = playerDistance / (distanceToMove * timesRepeated);
            int playerPassed = Mathf.FloorToInt(division);

            Debug.Log(playerPassed + " -> " + timesRepeated);
            if(playerPassed >= 1)
            {
                MoveToNextPosition();
            }
            
        }
        

    }

    [ContextMenu("MoveToNextPosition")]
    public void MoveToNextPosition()
    {
        Debug.Log("Moved");
        floors[currentIndex].position += (Vector3.forward * distanceToMove * floors.Length);
        timesRepeated++;
        currentIndex = (currentIndex + 1 < floors.Length) ? currentIndex + 1 : 0;
    }



}
