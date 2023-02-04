using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TimeHandler timehandler;


    [Header("Time")]
    [SerializeField] private TextMeshProUGUI timeText;

    private void Awake()
    {
        timehandler = GameObject.FindObjectOfType<TimeHandler>();
    }

    private void Start()
    {
        if(timehandler == null)
        {
            Debug.LogError("Time Handler is missing");
        }

        timehandler.timeChangeCallback += UpdateTimeUI;
    }


    private void UpdateTimeUI()
    {
        timeText.SetText(timehandler.getGlobalTimeSecondsFormated());
    }
}
