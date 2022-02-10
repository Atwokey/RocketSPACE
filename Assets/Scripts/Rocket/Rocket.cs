using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RocketMovement))]
public class Rocket : MonoBehaviour
{
    private int _batteryCount;
    private RocketMovement _movement;
    public RocketMovement Movement => _movement;
    public int BatteryCount => _batteryCount;
    public event UnityAction GameOver;
    public event UnityAction<int> ChangeCurrentBatteryCount;


    private void Start()
    {
        _movement = GetComponent<RocketMovement>();
        _movement.enabled = false;

        LoadStat();

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
        SaveStat();
    }

    private void LoadStat()
    {
        RocketData data = SaveSystem.LoadRocket();

        if(data == null)
        {
            ResetStat();
            return;
        }

        _batteryCount = SaveSystem.LoadRocket().BatteryCount;
    }

    public void SaveStat()
    {
        SaveSystem.SaveRocket(this);
    }

}
