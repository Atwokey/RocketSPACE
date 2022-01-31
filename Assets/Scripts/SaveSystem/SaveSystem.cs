using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static BinaryFormatter _formatter = new BinaryFormatter();
    private static readonly string _path = Application.persistentDataPath + "/rocket.space";
    private static FileStream _stream;

    public static void SaveRocket(Rocket rocket)
    {
        StreamOn(FileMode.Create);
        RocketData data = new RocketData(rocket);
        _formatter.Serialize(_stream, data);
        StreamOff();

    }

    public static RocketData LoadRocket()
    {
        if (!File.Exists(_path))
            return null;

        StreamOn(FileMode.Open);
        RocketData data = _formatter.Deserialize(_stream) as RocketData;
        StreamOff();

        return data;
    }

    private static void StreamOn(FileMode mode)
    {
        _stream = new FileStream(_path, mode);
    }

    private static void StreamOff()
    {
        _stream.Close();
    }
}
