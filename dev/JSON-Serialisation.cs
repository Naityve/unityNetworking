using UnityEngine;

public class JsonSerialisationExample : MonoBehaviour
{
    async void Start()
    {
        var basicObject = new BasicObject
        {
            shield = 100,
            health = 50,
            name = "Sven The Explorer",
            position = new Vector3(1,2,3)
        };

        string json = JsonUtility.ToJson(basicObject);
        Debug.Log(json);

        // JSON
        
        BasicObject copy = JsonUtility.
        FromJson<BasicObject>(json);
        Vector3 pos = copy.position;
        Debug.Log($"{copy.name} await {pos.x}, {pos.y}, {pos.z}");

        // BYTES

        byte[] bytes = Encoding.ASCII.GetBytes(json);
        Debug.Log($"{bytes[0]:x} {bytes[1]:x} {bytes[2]:x} {bytes[3]:x}");

        string jsonFromBytes = Encoding.ASCII.GetString(bytes);
        BasicObject copy = JsonUtility.FromJson<BasicObject>(jsonFromBytes);
        Vector3 pos = copy.position;
        Debug.Log($"{copy.name} await {pos.x}, {pos.y}, {pos.z}");
    }
}