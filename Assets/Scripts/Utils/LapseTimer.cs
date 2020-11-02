using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A timer
/// </summary>
public class LapseTimer : MonoBehaviour
{
	#region Fields
	private int currentLapseCount = 0;

	// timer execution
	public float elapsedSeconds = 0;

	LapsePassedEvent lapsePassedEvent = new LapsePassedEvent();

	private bool isRunning = false;
	
	#endregion
	
	#region Properties

	public float Lapse{get; set;}

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (isRunning)
        {
			elapsedSeconds += Time.deltaTime;
			
			if ((int)(elapsedSeconds / Lapse) > currentLapseCount)
			{
				Debug.Log($"{elapsedSeconds}, {Lapse}, {(int)(elapsedSeconds / Lapse)}, {currentLapseCount}");
				currentLapseCount = (int)(elapsedSeconds / Lapse);
				Debug.Log("llegie");
				lapsePassedEvent.Invoke();
			}
		}
		
	}

	public void Run()
    {	
		elapsedSeconds = 0;
		isRunning = true;
	}

	public void AddTimerLapseListener(UnityAction listener)
	{
		lapsePassedEvent.AddListener(listener);
	}

	#endregion
}
