using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper5 : Paper
{
    private void Start()
    {
        FristRotate(status);
    }

    public override void Combination()
    {
        if (isSpine)
            return;

        isSpine = true;
        StartCoroutine(CoroutineComb(45, 0.2f, 0f));
    }

    public override void Return()
    {
        if (isSpine)
            return;

        isSpine = true;
        StartCoroutine(CoroutineComb(-45, -0.2f, 0f));
    }
}
