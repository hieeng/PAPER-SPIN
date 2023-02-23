using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{
    [SerializeField] float moveTime;
    public void OnADS()
    {
        StartCoroutine(CoruotineMove(180));
    }

    public void OffADS()
    {
        StartCoroutine(CoruotineMove(-180));
    }

    IEnumerator CoruotineMove(int x)
    {
        var time = 0f;
        var origin = transform.position;
        var nexPos = transform.position;
        nexPos.x += x;

        while (time <= moveTime)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(origin, nexPos, time / moveTime);
            yield return null;
        }
    }
}
