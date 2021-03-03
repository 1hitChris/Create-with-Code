using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSkinAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        string currentSpriteName = spriteRenderer.sprite.name;

        foreach (var sprite in sprites)
        {
            if (sprite.name == currentSpriteName)
            {
                spriteRenderer.sprite = sprite;
                return;
            }
        }
    }
}
