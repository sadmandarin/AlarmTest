using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    private string[] timeUrls = { "https://yandex.com/time/sync.json" };

    [SerializeField] private TimeContainer _timeContainer;

    private void Awake()
    {
        StartCoroutine(TimeInitialize());
    }

    private IEnumerator TimeInitialize()
    {
        yield return StartCoroutine(_timeContainer.SynchronizeTime(timeUrls));

        SceneManager.LoadScene(1);
    }

}