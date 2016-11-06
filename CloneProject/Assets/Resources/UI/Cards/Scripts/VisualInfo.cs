using UnityEngine;
using System.Collections;

public class VisualInfo
{
    //Sprite Renderer - displays the sprites
    public Sprite spriteSheet = null;
    //Animator -- updates the sprite frame
    public RuntimeAnimatorController runtimeAnimator = null;

    public bool Load(string spriteURL, string animatorURL)
    {
        if (null == spriteURL || null == animatorURL)
            return false;

        spriteSheet = Resources.Load<Sprite>(spriteURL);
        if (spriteSheet == null)
            return false;

        runtimeAnimator = Resources.Load<RuntimeAnimatorController>(animatorURL);
        if (animatorURL == null)
        {
            if (spriteSheet)
                Resources.UnloadAsset(spriteSheet);
            return false;
        }

        return true;

    }

    public Sprite Sprite { get { return spriteSheet; } }
    public RuntimeAnimatorController RuntimeAnimatorController { get { return runtimeAnimator; } }

}
