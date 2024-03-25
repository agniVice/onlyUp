using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private TextMeshProUGUI adText;

    private float time;
    private bool isWorking = true;
    public float currentAdTime = 3;
    


    private void Start()
    {
        StartTimer();
        StartAdTimer();
        adText.text = "";
    }
    private void FixedUpdate()
    {
        if (isWorking)
        {
            time += Time.fixedDeltaTime;
            text.text = Mathf.FloorToInt(time / 60).ToString() + " minutes";

            // Cделано дл€ предупреждени€ игрока об рекламе за 3 секунды

            //if(≈сли реклама сейчас будет показана)
            //{
            //  currentAdTime -= Time.fixedDeltaTime;
            //  adText.text = "Ad in: " + Mathf.FloorToInt(currentAdTime+1).ToString();
            //  if (currentAdTime <= 0)
            //  {
            //      // ѕоказать рекламу
            //      currentAdTime = 3;
            //      adText.text = "";
            //      return;
            //  }
            //  else
            //      adText.text = "";
            //}
        }
    }
    private void StartTimer()
    {
        time = 0f;
    }
    private void StartAdTimer()
    {
        currentAdTime = 3f;
    }
    public float GetMinutes()
    {
        return Mathf.FloorToInt(time / 60);
    }
}
