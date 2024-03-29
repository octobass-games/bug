﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AddShadow : MonoBehaviour
{
    public bool AutoShadow = true;
    private ShadowController ShadowController;
    public List<SpriteWithShadow> CustomShadows;
    public string ShadowId = "default";

    private SpriteRenderer Sprite;
    private Color OriginalColour;

    public string GetId () => ShadowId;

    void Awake()
    {
        ShadowController = FindObjectOfType<ShadowController>();
        Sprite = GetComponent<SpriteRenderer>();
        OriginalColour = Sprite.color;
        ShadowController.Register(this);
    }



    public void UpdateSprite(Sprite sprite)
    {
        var spriteWithShadow = CustomShadows.Find(s => s.Sprite == sprite);
        if (spriteWithShadow != null)
        {
            if (ShadowController.ShadowsOn)
            {
                Sprite.sprite = spriteWithShadow.Shadow;
            }else
            {
                Sprite.sprite = sprite;
            }
        }
    }

    public void ShadowOn(bool on)
    {
        if (on)
        {
            TurnShadowOn();
        }else
        {
            TurnShadowOff();
        }
    }

    private void TurnShadowOn()
    {
        if (AutoShadow)
        {
            Sprite.color = ShadowController.ShadowColour;

        } else if (CustomShadows.Count > 0)
        {
           var spriteWithShadow = CustomShadows.Find(s => s.Sprite == Sprite.sprite);
            if (spriteWithShadow != null)
            {
                Sprite.sprite = spriteWithShadow.Shadow;
            }
        }


    }
    private void TurnShadowOff()
    {
        if (AutoShadow)
        {
            Sprite.color = OriginalColour;

        }
        else if (CustomShadows.Count > 0)
        {
            var spriteWithShadow = CustomShadows.Find(s => s.Shadow == Sprite.sprite);

            if (spriteWithShadow != null)
            {
                Sprite.sprite = spriteWithShadow.Sprite;
            }
        }
    }

    void OnDestroy()
    {
        ShadowController.Unregister(this);
    }
}