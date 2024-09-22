using System.Collections;
using UnityEngine;

public class SyncronizeTime : MonoBehaviour
{
    private string[] timeUrls = { "https://thingproxy.freeboard.io/fetch/https://yandex.com/time/sync.json" };
    private int _synchTime = 3600;

    [SerializeField] private TimeContainer _timeContainer;

    private void Awake()
    {
        StartCoroutine(SynchronizeTime());
    }

    private IEnumerator SynchronizeTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_synchTime);

            StartCoroutine(_timeContainer.SynchronizeTime(timeUrls));
        }    }
}
