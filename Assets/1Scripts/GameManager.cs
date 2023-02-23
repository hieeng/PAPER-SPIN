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

    public bool isCombine = false;
    public bool correct;
    public int level;
    public int papersNum;
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
            if (paperLevel[level].papers[i].isSpine)
                return;
        
        papersNum = paperLevel[level].papers.Length;
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Combination();
            //papers[i].Combination();
        isCombine = true;
    }

    public void ReturnPaper()
    {
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Return();
            //papers[level][i].Return();
        isCombine = false;
    }

    public void SahkePaper()
    {
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Sahke();
    }

    public void ClearCheck()
    {
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            if (paperLevel[level].papers[i].status != 0)
                return;

        correct = true;
        uiManager.Clear(level);
        for (int i = 0, size = paperLevel[level].papers.Length; i < size; i++)
            paperLevel[level].papers[i].Clear();
        for (int i = 0, size = particle.Length; i < size; i++)
            particle[i].Play();
        StartCoroutine(CoruotineClear());
    }

    IEnumerator CoruotineClear()
    {
        var time = 0f;

        //이미지 애니메이션 동안 2초 대기
        while (time <= 2f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        levelObj[level].SetActive(false);
        uiManager.CircleCollor(level);
        level++;
        if (level == paperLevel.Length)
        {
            uiManager.OnCut();
            yield break;
        }
        levelObj[level].SetActive(true);
        player.firstClick = true;
        uiManager.OnADS();
        uiManager.LevelUpdate(level);
        isCombine = false;
        correct = false;
    }

    public void OffStartText()
    {
        uiManager.OffStartText();
    }

    public void OffADS()
    {
        uiManager.OffADS();
    }
}
