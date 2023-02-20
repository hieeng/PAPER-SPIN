using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera cam;
    private RaycastHit hit;

    private void Update() 
    {
        Get();
    }

    private void Get()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        
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

        GameManager.Instance.Check();
        if (!GameManager.Instance.correct)
            GameManager.Instance.ReturnPaper();
    }
}