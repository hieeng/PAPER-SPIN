using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] ImageAni[] image;
    [SerializeField] Text LevelText;
    [SerializeField] Text StartText;

    public void Clear()
    {
        image[GameManager.Instance.level].GameClear();
    }

    public void OffStartText()
    {
        StartText.gameObject.SetActive(false);
    }

    public void LevelUpdate()
    {
        LevelText.text = string.Format("LEVEL {0:n0}", GameManager.Instance.level + 1);
    }
}
