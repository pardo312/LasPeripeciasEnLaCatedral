using System.Collections;
using UnityEngine;

public class PlayerHealth : IntEventInvoker
{
    [SerializeField] private int lifes;
    private bool hasInvulnerability = false;
    private GameLostEvent gameLostEvent;

    private SpriteRenderer spriteRender;
    private Animator animator;
    private void Start()
    {
        gameLostEvent = new GameLostEvent();
        unityEvents.Add(EventName.GameLostEvent, gameLostEvent);
        EventManager.AddInvoker(EventName.GameLostEvent, this);

        EventManager.AddListener(EventName.DamageReceivedEvent, TakeDamage);

        spriteRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private IEnumerator DamageAnim()
    {
        animator.SetBool(Lvl1PlayerAnimStates.Damaged.ToString(), true);
        for (int i = 0; i < 10; i++)
        {
            spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, 0.8f);
            yield return new WaitForSeconds(0.1f);
            spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        hasInvulnerability = false;
        animator.SetBool(Lvl1PlayerAnimStates.Damaged.ToString(), false);
    }

    private void TakeDamage(int unused)
    {
        if (!hasInvulnerability)
        {
            hasInvulnerability = true;
            lifes -= 1;
            if (lifes <= 0)
            {
                gameLostEvent.Invoke(0);
                Destroy(gameObject);
                return;
            }
            StartCoroutine(DamageAnim());
        }
    }
}
