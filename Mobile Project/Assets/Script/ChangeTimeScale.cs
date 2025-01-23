using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeScale: MonoBehaviour
{
    public void StopGame(float delay)
    {
        StartCoroutine(StopGameCoroutine(delay));
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator StopGameCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;
    }
}
