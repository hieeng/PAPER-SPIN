using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAni : MonoBehaviour
{
    Animator anim;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    public void GameClear()
    {
        Debug.Log(GameManager.Instance.level);
        gameObject.SetActive(true);
        anim.SetTrigger("Clear");
    }
}
