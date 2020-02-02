using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator animator;

    public float PlayCanvasOut()
    {
        animator.Play("CanvasOut");
        // !good solution
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    public float PlayCanvasIn()
    {
        animator.Play("CanvasIn");
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    public void GoToSettingPage()
    {
        animator.Play("CanvasSettingsPageIn");
    }

    public void GoFromSettingPage()
    {
        animator.Play("CanvasSettingsPageOut");
    }
}
