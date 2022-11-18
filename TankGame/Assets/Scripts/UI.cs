using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;
using Unity.Mathematics;

public class UI : MonoBehaviour
{
    public Text turnTimerP1;
    public Text turnTimerP2;
    public Slider mySlider;
    public TMP_Text sliderText;
    public float bulletSpeed;
    public TankControler Tank1;
    public TankControler Tank2;
    public Slider hpBarP1;
    public Slider hpBarP2;
    public Text hpTextP1;
    public Text hpTextP2;

    void Start()
    {

    }
    public void ChangeText()
    {
        
    }
    void FixedUpdate()
    {
        float sliderValue = mySlider.value;
        bulletSpeed = sliderValue;
        sliderText.text = sliderValue.ToString("F0") + "%";
        
        float timerP1 = Tank1.timerP1;
        turnTimerP1.text = "Player 1 seconds left " + timerP1.ToString("F1");

        float timerP2 = Tank2.timerP2;
        turnTimerP2.text = "Player 2 seconds left " + timerP2.ToString("F1");

        float hpP1 = Tank1.hpP1;
        hpBarP1.value = hpP1;

        float hpP2 = Tank2.hpP2;
        hpBarP2.value = hpP2;

        hpTextP1.text = hpP1.ToString() + " HP";
        hpTextP2.text = hpP2.ToString() + " HP";
    }
}