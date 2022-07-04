using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
    public float randomTimeStartWatching = 15f;
    public float randomTimeWatching = 0f;

    public float startWatchingTimeMin;
    public float startWatchingTimeMax;

    public float WatchingTimeMin;
    public float WatchingTimeMax;

    public bool isWatching = false;

    private void Update()
    {

        if (randomTimeWatching <= 0f && !isWatching)
        {
            randomTimeStartWatching -= Time.deltaTime;

            if (randomTimeStartWatching <= 0f)
            {
                randomTimeWatching = Random.Range(WatchingTimeMin, WatchingTimeMax);
                SetIsWatching();
            }
        }
        else if (randomTimeWatching > 0f && isWatching)
        {
            randomTimeWatching -= Time.deltaTime;

            if (randomTimeWatching <= 0f)
            {
                randomTimeStartWatching = Random.Range(startWatchingTimeMin, startWatchingTimeMax);
                SetIsWatching();
            }
        }
    }

    private void SetIsWatching()
    {
        isWatching = !isWatching;
    }
}
