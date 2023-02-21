using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper2 : Paper
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
        if (GameManager.Instance.papersNum == 4)
            StartCoroutine(CoroutineComb(-45, 0.2f, -0.2f));
        else
            StartCoroutine(CoroutineComb(-45, 0.2f, -0.4f));
    }

    public override void Return()
    {
        if (isSpine)
            return;
            
        isSpine = true;
        if (GameManager.Instance.papersNum == 4)
            StartCoroutine(CoroutineComb(45, -0.2f, 0.2f));
        else
            StartCoroutine(CoroutineComb(45, -0.2f, 0.4f));
    }
}
