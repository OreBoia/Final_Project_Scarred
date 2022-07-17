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

    public float percentage;
    public float percentageTimeToEnd;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        percentageTimeToEnd = randomTimeStartWatching * percentage / 100;
    }

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
                percentageTimeToEnd = randomTimeStartWatching * percentage / 100;
                //Debug.Log(percentageTimeToEnd);
                SetIsWatching();
            }
        }

        SetAnimation();
    }

    private void SetAnimation()
    {
        //animator.SetBool("isWatching", isWatching);

        if (!MinigameLeafController.Instance.endMinigame)
        {
            if (isWatching)
            {
                animator.SetTrigger("Beccato");
            }
            else if (randomTimeStartWatching > percentageTimeToEnd)
            {
                animator.SetTrigger("Distratta");
            }
            else if (randomTimeStartWatching < percentageTimeToEnd)
            {
                animator.SetTrigger("Triggered");
            }
        }
        else
        {
            animator.SetTrigger("Beccato");
        }

        //if (randomTimeStartWatching < percentageTimeToEnd)
        //{
        //    Debug.Log("WARN");
        //}
    }

    private void SetIsWatching()
    {
        isWatching = !isWatching;

        //animator.SetBool("isWatching", isWatching);
    }
}
