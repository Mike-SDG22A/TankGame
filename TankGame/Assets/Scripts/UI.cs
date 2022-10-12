using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using TMPro.EditorUtilities;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider mySlider;
    public TMP_Text myText;
    public TMP_Text sliderText;
    public void ChangeText() 
    {
        
    }
    private void Update()
    {
        sliderText.text = mySlider.value.ToString();
    }
}
