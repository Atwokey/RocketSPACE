using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryCountDisplay : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private TMP_Text _currentCount;

    private void OnEnable()
    {
        _rocket.ChangeCurrentBatteryCount += OnChangeCurrentBatteryCount;
    }

    private void OnDisable()
    {
        _rocket.ChangeCurrentBatteryCount -= OnChangeCurrentBatteryCount;
    }

    private void OnChangeCurrentBatteryCount(int value)
    {
        _currentCount.text = value.ToString();
    }
}
