using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] SpriteRenderer image;
    [SerializeField] float spinTime;
    [SerializeField] Vector3 forceVec;
    [SerializeField] int force;

    public int status;
    public bool isSpine;

    private void Awake() 
    {
        status = Random.Range(0, 4);
        rigid = GetComponent<Rigidbody>();
    }

    protected void FristRotate(int value)
    {
        switch(value)
        {
            case 0 :
            {
                var rotEulerAngle = transform.rotation.eulerAngles;
                rotEulerAngle.z = 45;
                transform.rotation = Quaternion.Euler(rotEulerAngle);
                break;
            }
            case 1 :
            {
                var rotEulerAngle = transform.rotation.eulerAngles;
                rotEulerAngle.z = 135;
                transform.rotation = Quaternion.Euler(rotEulerAngle);
                break;
            }
            case 2 :
            {
                var rotEulerAngle = transform.rotation.eulerAngles;
                rotEulerAngle.z = 225;
                transform.rotation = Quaternion.Euler(rotEulerAngle);
                break;
            }
            case 3 :
            {
                var rotEulerAngle = transform.rotation.eulerAngles;
                rotEulerAngle.z = 315;
                transform.rotation = Quaternion.Euler(rotEulerAngle);
                break;
            }
        }
        Debug.Log(status);
    }

    public void Spin()
    {
        if (isSpine)
            return;
        if (GameManager.Instance.correct)
            return;
        if (GameManager.Instance.isCombine)
            return;
        isSpine = true;
        StartCoroutine(CoruotineSpin(status));
    }

    IEnumerator CoruotineSpin(int vaule)
    {
        var time = 0f;
        var origin = transform.rotation;
        var rotEulerAngle = transform.rotation.eulerAngles;
        rotEulerAngle.z += 90f;
        var rot = Quaternion.Euler(rotEulerAngle);

        switch(vaule)
        {
            case 3 :
            {
                status = 0;
                break;
            }
            default :
            {
                status++;
                break;
            }
        }

        Debug.Log(status);
        while (time <= spinTime)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(origin, rot, time / spinTime);
            yield return null;
        }
        isSpine = false;
    }

    public virtual void Combination() {}
    public virtual void Return() {}

    protected IEnumerator CoroutineComb(float angle, float x, float y)
    {
        if (GameManager.Instance.correct)
            yield break;

        GameManager.Instance.isCombine = true;
        var time = 0f;
        var originRot = transform.rotation;
        var rotEulerAngle = transform.rotation.eulerAngles;
        rotEulerAngle.z += angle;
        var rot = Quaternion.Euler(rotEulerAngle);

        var originPos = transform.position;
        var nextPos = transform.position;
        nextPos.x += x;
        nextPos.y += y;

        while (time <= spinTime)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(originRot, rot, time / spinTime);
            transform.position = Vector3.Lerp(originPos, nextPos, time / spinTime);
            yield return null;
        }
        isSpine = false;
    }

    public void Clear()
    {
        rigid.isKinematic = false;
        rigid.AddForce(forceVec * force);
        image.color = Color.black;
    }
}
