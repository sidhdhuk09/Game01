using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 Offset;

   public void SetHealth(float health,float maxhealth)
    {
        slider.gameObject.SetActive(health < maxhealth);
        slider.value = health;
        slider.maxValue = maxhealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);



        
    }
    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
