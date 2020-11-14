using UnityEngine;

public class Palomino2 : MonoBehaviour
{
    [SerializeField] private Palomino palomino;
    private Animator animator;

    public void Initialize()
    {
        animator = GetComponent<Animator>();
        palomino.durationTimer.AddTimerFinishedListener(SetLeaveAnimation);
    }

    public void HandleApparitionAnimFinished()
    {
        palomino.RunDurationTimer();
    }

    private void SetLeaveAnimation()
    {
        animator.SetBool("Leave", true);
    }

    public void HandleLeaveAnimFinished()
    {
        palomino.RunSpawnTimer();
        gameObject.SetActive(false);
    }
}
