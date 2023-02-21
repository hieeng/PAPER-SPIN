using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper1 : Paper
{
    private void Start()
    {
        FristRotate(status);
    }

    public override void Combination()
    {
        if (isSpine)
            return;
        StartCoroutine(CoroutineComb(45, -0.2f, -0.2f));
    }

    public override void Return()
    {
        if (isSpine)
            return;
        StartCoroutine(CoroutineComb(-45, 0.2f, 0.2f));
    }
}
