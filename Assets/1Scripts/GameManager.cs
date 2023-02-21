using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] Player player;
    [System.Serializable]
    public class PaperList
    {
        public Paper[] papers;
    }
    [SerializeField] PaperList[] paperLevel = new PaperList[5];

    [SerializeField] GameObject[] levelObj;

    [SerializeField] ParticleSystem[] particle;

    public bool correct;
    public int level;
    static public GameManager Instance;
    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void CombinePaper()
    {
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Combination();
            //papers[i].Combination();
    }

    public void ReturnPaper()
    {
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Return();
            //papers[level][i].Return();
    }

    public void ClearCheck()
    {
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
        {
            if (paperLevel[level].papers[i].status != 0)
                return;
        }

        correct = true;
        uiManager.Clear();
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Clear();
        for (int i = 0, size = particle.Length; i < size; i++)
            particle[i].Play();
        StartCoroutine(CoruotineClear());
    }

    IEnumerator CoruotineClear()
    {
        var time = 0f;

        while (time <= 2f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        levelObj[level].SetActive(false);
        level++;
        levelObj[level].SetActive(true);
        uiManager.LevelUpdate();
        correct = false;
    }

    public void OffStartText()
    {
        uiManager.OffStartText();
    }
}
