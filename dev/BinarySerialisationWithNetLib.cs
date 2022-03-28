using UnityEngine;

public class BinarySerialisationWithNetLib : MonoBehaviour
{
    void Start()
    {
        MyData data = new MyData
        {
            shield = 100,
            health = 50,
            name = "Sven The Destroyer",
            position = new Vector3(1,2,3)
        };
        Debug.Log($"Original: {data}");
    }

    byte[] bytes = data.ToArray();
    MyData copy = bytes.ToStruct<MyData>();

    Debug.Log($"Copy: {copy}");

    byte[] jsonBytes = data.ToJsonBinary();
    MyData jsonCopy = jsonBytes.FromJsonBinary<MyData>();
    Debug.Log($"Json Copy: {jsonCopy}");
}