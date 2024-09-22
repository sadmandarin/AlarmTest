using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "TimeContainer", menuName = "SO/TimeContainer", order = 0)]
public class TimeContainer : ScriptableObject
{
    public DateTime SynchTime;
    public bool IsTimeSynchronized = false;

    public IEnumerator SynchronizeTime(string[] timeUrls)
    {
        foreach (var url in timeUrls)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                ParseJsonForTime(request.downloadHandler.text);

                IsTimeSynchronized = true;

                break;
            }
        }
    }
    private void ParseJsonForTime(string json)
    {
        TimeResponse timeResponse = JsonUtility.FromJson<TimeResponse>(json);

        long unixTimeInMilliseconds = timeResponse.time;

        DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeInMilliseconds).LocalDateTime;

        SynchTime = dateTime;

        Debug.Log("Метка времени в миллисекундах: " + unixTimeInMilliseconds);
        Debug.Log("Преобразованное время: " + dateTime);
    }
}

[System.Serializable]
public class TimeResponse
{
    public long time;
}
