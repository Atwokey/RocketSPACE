using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryCountDisplay : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text _currentCount;


    private void Start()
    {
        _gameManager.Rocket.ChangeCurrentBatteryCount += OnChangeCurrentBatteryCount;
    }

    private void OnDisable()
    {
        _gameManager.Rocket.ChangeCurrentBatteryCount -= OnChangeCurrentBatteryCount;
    }

    private void OnChangeCurrentBatteryCount(int value)
    {
        _currentCount.text = value.ToString();
    }
}
