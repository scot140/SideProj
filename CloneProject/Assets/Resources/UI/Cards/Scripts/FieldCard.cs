using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class FieldCard : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void SetVisuals(ref VisualInfo visual)
    {
        Sprite = visual.Sprite;
        RuntimeAnimatorController = visual.RuntimeAnimatorController;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    #region Properties

    public Sprite Sprite
    {
        get { return spriteRenderer.sprite; }
        set { spriteRenderer.sprite = value; }
    }

    public RuntimeAnimatorController RuntimeAnimatorController
    {
        get { return animator.runtimeAnimatorController; }
        set { animator.runtimeAnimatorController = value; }
    }

    #endregion

}
