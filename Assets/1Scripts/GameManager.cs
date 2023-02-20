using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Paper[] papers;

    public bool correct;
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
        for (int i = 0, size = papers.Length; i < size; i++)
            papers[i].Combination();
    }

    public void ReturnPaper()
    {
        for (int i = 0, size = papers.Length; i < size; i++)
            papers[i].Return();
    }

    public void Check()
    {
        for (int i = 0, size = papers.Length; i < size; i++)
        {
            if (papers[i].status != 0)
                return;
        }

        correct = true;
    }
}
