using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [Header("Scoring")]
    public Text scoreText;
    public Text multiplierText;
    public Slider multiplierSlider;

    [Header("Proximity")]
    public Slider proximitySlider;

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetMaxProximity(float maxDistance)
    {
        proximitySlider.maxValue = maxDistance;
        proximitySlider.value = 0f;
    }

    public void SetProximityValue(float currentDistance)
    {
        proximitySlider.value = currentDistance;
    }

    public void SetMultiplierMaxTime(float maxTime)
    {
        multiplierSlider.maxValue = maxTime;
    }
   
    public void SetMultiplierData(int mutiplier, float percent)
    {
        multiplierText.text = "x"+ mutiplier.ToString();
        multiplierSlider.value = percent;
    }

}
