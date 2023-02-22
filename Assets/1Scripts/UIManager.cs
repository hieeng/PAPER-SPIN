using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] ImageAni[] image;
    [SerializeField] Image[] circle;
    [SerializeField] GameObject cut;
    [SerializeField] Text LevelText;
    [SerializeField] Text StartText;

    public void Clear(int level)
    {
        image[level].GameClear();
    }

    public void OffStartText()
    {
        StartText.gameObject.SetActive(false);
    }

    public void LevelUpdate(int level)
    {
        LevelText.text = string.Format("LEVEL {0:n0}", level + 1);
    }

    public void CircleCollor(int level)
    {
        if (level >= 4)
            return;
        circle[level].color = new Color(5/255f, 190/255f, 0f, 1f);
    }

    public void OnCut()
    {
        cut.SetActive(true);
    }
}
