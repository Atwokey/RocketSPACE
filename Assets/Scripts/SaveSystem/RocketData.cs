using UnityEngine;

[System.Serializable]
public class RocketData
{
    private int _batteryCount;

    public int BatteryCount => _batteryCount;

    public RocketData(Rocket rocket)
    {
        _batteryCount = rocket.BatteryCount;
    }
}
