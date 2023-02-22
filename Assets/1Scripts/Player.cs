using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera cam;
    private RaycastHit hit;

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

        while (time <= 0.5f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        GameManager.Instance.ClearCheck();
        if (!GameManager.Instance.correct)
            GameManager.Instance.ReturnPaper();
    }
}
