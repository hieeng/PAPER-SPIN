using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SprtieOutline : MonoBehaviour
{
    [SerializeField] Color color = Color.white;

    [Range(0, 16)]
    [SerializeField] int size = 1;

    SpriteRenderer sprite;

    private void Awake() 
    {
        sprite = GetComponent<SpriteRenderer>();

        UpdateOutline(true);
    }

    private void OnDisable()
    {
        UpdateOutline(false);
    }

    private void Update() {

        UpdateOutline(true);
    }

    private void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        sprite.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        mpb.SetFloat("_OutlineSize", size);
        sprite.SetPropertyBlock(mpb);
    }
}
