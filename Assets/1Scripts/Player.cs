using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera cam;
    private RaycastHit hit;
    public bool firstClick = false;

    private void Update() 
    {
        Click();
    }

    private void Click()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        if (GameManager.Instance.isCombine)
            return;

        GameManager.Instance.OffStartText();
        if (firstClick)
        {
            firstClick = false;
            GameManager.Instance.OffADS();
        }
        
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Paper"))
                hit.collider.gameObject.GetComponent<Paper>().Spin();
            else
            {
                GameManager.Instance.CombinePaper();
                StartCoroutine(CoruotineCheck());
            }
        }
    }

    IEnumerator CoruotineCheck()
    {
        var time = 0f;

        //이미지 잠시 확인시간
        while (time <= 0.5f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        GameManager.Instance.ClearCheck();

        //틀렸을 때
        if (!GameManager.Instance.correct)
        {
            time = 0f;

            GameManager.Instance.SahkePaper();
            //흔들리는 시간 대기
            while (time <= 0.5f)
            {
                time += Time.deltaTime;
                yield return null;
            }
            GameManager.Instance.ReturnPaper();
        }
    }
}
