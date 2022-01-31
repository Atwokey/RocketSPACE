using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private int _batteryCount;

    public event UnityAction GameOver;
    public event UnityAction<int> ChangeCurrentBatteryCount;
    public int BatteryCount => _batteryCount;

    private void Start()
    {
        transform.position = _startPoint.position;
        ChangeCurrentBatteryCount?.Invoke(_batteryCount);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void Collect()
    {
        _batteryCount++;
        ChangeCurrentBatteryCount?.Invoke(_batteryCount);
    }

    public void ResetStat()
    {
        _batteryCount = 0;
    }

    public void LoadStat()
    {
        RocketData data = SaveSystem.LoadRocket();

        _batteryCount = data.BatteryCount;
    }

    public void SaveStat()
    {
        SaveSystem.SaveRocket(this);
    }

}
