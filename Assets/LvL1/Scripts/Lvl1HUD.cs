using UnityEngine;
using UnityEngine.UI;

public class Lvl1HUD: IntEventInvoker
{
	[SerializeField] private Text[] txtItems;
	[SerializeField] private PickableFallingItem[] pickableFallingItems;
	[SerializeField] private GameObject[] lifes;
	[SerializeField] private FallingItemSpawner fallingItemSpawner;

	[SerializeField] private GameObject gameWonMenu;
	[SerializeField] private GameObject gameLostMenu;

	private GameWonEvent gameWonEvent;

    private void Awake()
    {
		gameWonEvent = new GameWonEvent();

	}

    private void Start()
	{
		unityEvents.Add(EventName.GameWonEvent, gameWonEvent);
		EventManager.AddInvoker(EventName.GameWonEvent, this);

		EventManager.AddListener(EventName.DamageReceivedEvent, InactiveHeart);
		InitializeItems();
	}

	private void InitializeItems()
    {
		for (int i = 0; i < pickableFallingItems.Length; i++)
		{
			PickableFallingItem currentPickableFallingItem = pickableFallingItems[i];

			for (int j = 0; j < txtItems.Length; j++)
			{
				Text currentItemText = txtItems[j];
				if (currentItemText.name == currentPickableFallingItem.name)
				{
					currentItemText.text = $"0/{currentPickableFallingItem.amountToCollect}";
				}
			}
		}
	}

	public void CollectItem(string itemName)
    {
		int completedItems = 0;

		for (int j = 0; j < txtItems.Length; j++)
		{
			Text currentItemText = txtItems[j];

			string text = currentItemText.text;
			int currentAmountCollected = (int)char.GetNumericValue(text[0]);
			int amountToCollect = (int)char.GetNumericValue(text[text.Length - 1]);
			
			if (currentItemText.name == itemName)
			{
				currentAmountCollected += 1;

				if (currentAmountCollected <= amountToCollect)
                {
					currentItemText.text = $"{currentAmountCollected}{text.Substring(1)}";
				}
                
				if(currentAmountCollected == amountToCollect)
                {
					fallingItemSpawner.RemoveItemFromPool(itemName);
				}
			}

			if(currentAmountCollected == amountToCollect)
            {
				completedItems++;
			}
		}

		if(completedItems == txtItems.Length)
        {
			AudioManager.Play(AudioClipName.Lvl1GameWon);
			gameWonEvent.Invoke(0);
			Instantiate(gameWonMenu);
		}
	}

    private void InactiveHeart(int unused)
	{
		for(int i = lifes.Length - 1; i >= 0; i--){
            if (lifes[i].activeSelf)
            {
				lifes[i].SetActive(false);

				if(i == 0)
                {
					AudioManager.Play(AudioClipName.Lvl1GameLost);
					Instantiate(gameLostMenu);
                }

				break;
			}
		}		
	}
}
