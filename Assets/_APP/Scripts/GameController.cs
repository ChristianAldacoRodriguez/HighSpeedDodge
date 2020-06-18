using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [Header("Controllers")]
    public SpaceShipMovement movementController;
    public WorldGenerator worldGeneratorController;
    public ProximityDetector proximityDetectorController;
    public UIController uiController;

    [Header("Scoring")]
    public float score = 0f;
    public int currentMultiplier = 1;
    public float multiplierLifeTime = 0f;

    private void Start()
    {
        movementController.onMove = OnSpaceshipMoves;
        movementController.onUpdate = OnUpdateSpaceshipPosition;
        proximityDetectorController.onUpdateProximity = uiController.SetProximityValue;

        uiController.SetMaxProximity(proximityDetectorController.rayMaxDistance);
        uiController.SetMultiplierMaxTime(5f);


    }

    private void Update()
    {
        if(currentMultiplier > 1)
        {
            multiplierLifeTime -= Time.deltaTime;
            if(multiplierLifeTime <= 0f)
            {
                currentMultiplier--;
                //multiplierLifeTime = (currentMultiplier > 1) ? 15f / currentMultiplier : 0f;
                multiplierLifeTime = 5f;
            }
        }

        uiController.SetMultiplierData(currentMultiplier, multiplierLifeTime);
    }

    void OnUpdateSpaceshipPosition(float delta)
    {
        score += (delta * currentMultiplier);
        uiController.SetScore( Mathf.FloorToInt(score));
    }

    public void OnSpaceshipMoves(int side)
    {
        if(proximityDetectorController.distance < 10f)
        {
            currentMultiplier = 3;
            //multiplierLifeTime = 15f / currentMultiplier;
            multiplierLifeTime = 5;
            Debug.Log("x3");
        }
        else if(proximityDetectorController.distance < 20f)
        {
            currentMultiplier = 2;
            //multiplierLifeTime = 15f / currentMultiplier;
            multiplierLifeTime = 5;
            Debug.Log("x2");
        }
        else
        {
            //currentMultiplier = 1;
            //multiplierLifeTime = 0f;
            //Debug.Log("x1");
        }
    }

    


}
