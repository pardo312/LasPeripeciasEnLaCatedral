using UnityEngine;

public class Rubbish : IntEventInvoker
{
    [SerializeField] private int damage;
    private DamageReceivedEvent damageReceivedEvent;

    private void Start()
    {
        damageReceivedEvent = new DamageReceivedEvent();
        unityEvents.Add(EventName.DamageReceivedEvent, damageReceivedEvent);
        EventManager.AddInvoker(EventName.DamageReceivedEvent, this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(TagName.Player.ToString()))
        {
            damageReceivedEvent.Invoke(damage);
            gameObject.SetActive(false);
        }
    }
}
