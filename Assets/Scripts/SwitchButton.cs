using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] Sprite pressed;
    private SpriteRenderer renderer;
    private Collider2D coll;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    public void PressButton()
    {
        coll.enabled = false;
        renderer.sprite = pressed;
    }
}
