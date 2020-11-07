using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderTimer : IntEventInvoker
{
    private Slider slider;
    private CountdownTimer countdownTimer;
    private float duration;
    private GameLostEvent gameLostEvent;

    private void Start()
    {

        gameLostEvent = new GameLostEvent();
        unityEvents.Add(EventName.gameLostEvent, gameLostEvent);
        EventManager.AddInvoker(EventName.gameLostEvent, this);

        slider = GetComponent<Slider>();

        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.AddTimerFinishedListener(HandleTimerFinished);
        countdownTimer.Duration = duration;
        countdownTimer.Run();
    }

    public void Initialize(float duration)
    {
        this.duration = duration;
    }

    private void Update()
    {
        slider.value = countdownTimer.TimeLeft / countdownTimer.Duration;
    }

    private void HandleTimerFinished()
    {
        gameLostEvent.Invoke(0);
    }
}
