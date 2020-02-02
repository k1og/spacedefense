using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public Animator animator;
    public bool IsAnyClipAnimating => isAnyClipAnimating;
    private bool isAnyClipAnimating = false;

    public float GetCurrentClipLength()
    {
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }
    public void PlayClip(string name)
    {
        if (IsAnyClipAnimating) return;
        animator.Play(name);
        float duration = GetCurrentClipLength();
        StartCoroutine(UpdateIsAnyClipAnimatingCoroutine(duration));
    }

    IEnumerator UpdateIsAnyClipAnimatingCoroutine(float duration) 
    {
        isAnyClipAnimating = true;
        yield return new WaitForSeconds(duration);
        isAnyClipAnimating = false;
        yield return null;
    }
}
