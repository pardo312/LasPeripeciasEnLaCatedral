using UnityEngine.UI;

public class SliderTimer : IntEventInvoker
{
    private Slider slider;
    private CountdownTimer countdownTimer;

    private GameLostEvent gameLostEvent;

    private void Start()
    {

        gameLostEvent = new GameLostEvent();
        unityEvents.Add(EventName.gameLostEvent, gameLostEvent);
        EventManager.AddInvoker(EventName.gameLostEvent, this);

        slider = GetComponent<Slider>();

        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.Duration = 5f;
        countdownTimer.AddTimerFinishedListener(HandleTimerFinished);
        countdownTimer.Run();

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
