using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    private string[] timeUrls = {"http://worldtimeapi.org/api/timezone/Etc/UTC",
                                 "https://www.timeapi.io/api/Time/current/zone?timeZone=UTC"};

    [SerializeField] private TimeContainer _timeContainer;

    private void Awake()
    {
        StartCoroutine(TimeInitialize());
    }

    private IEnumerator TimeInitialize()
    {
        bool synchedTime = false;

        foreach (var url in timeUrls)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                SetTime(request.downloadHandler.text);
                synchedTime = true;
                break;
            }
            else
                continue;
        }

        if (!synchedTime)
        {
            _timeContainer.SynchTime = DateTime.UtcNow.ToLocalTime();
        }

        SceneManager.LoadScene(1);
    }

    private void SetTime(string json)
    {
        string timeString = ParseJsonForTime(json);
        if (DateTime.TryParse(timeString, out DateTime networkTime))
        {
            _timeContainer.SynchTime = networkTime.ToLocalTime();
        }
    }

    private string ParseJsonForTime(string json)
    {
        if (json.Contains("\"datetime\":\""))
        {
            int startIndex = json.IndexOf("\"datetime\":\"") + 12;
            int endIndex = json.IndexOf("\",", startIndex);
            return json.Substring(startIndex, endIndex - startIndex);
        }
        else if (json.Contains("\"dateTime\":\""))
        {
            int startIndex = json.IndexOf("\"dateTime\":\"") + 12;
            int endIndex = json.IndexOf("\",", startIndex);
            return json.Substring(startIndex, endIndex - startIndex);
        }
        return null;
    }
}