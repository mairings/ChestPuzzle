using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static IEnumerator DelayedAction(this MonoBehaviour monoBehaviour, float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
