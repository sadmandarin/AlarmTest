using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    private string[] timeUrls = { "https://thingproxy.freeboard.io/fetch/https://yandex.com/time/sync.json" };

    [SerializeField] private TimeContainer _timeContainer;
    private bool isTimeSynchronized;

    private void Awake()
    {
        StartCoroutine(TimeInitialize());
    }

    private IEnumerator TimeInitialize()
    {
        yield return StartCoroutine(_timeContainer.SynchronizeTime(timeUrls));

        if (_timeContainer.IsTimeSynchronized)
        {
            isTimeSynchronized = true;
            Debug.Log("Time synchronized successfully.");
        }
        else
        {
            Debug.LogWarning("Time synchronization failed.");
        }

        yield return new WaitForSeconds(1);

        if (isTimeSynchronized)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogError("Skipping scene load due to failed time synchronization.");
        }
    }

}