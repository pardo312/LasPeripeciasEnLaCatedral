using UnityEngine;
using UnityEngine.UI;

public class Lvl1HUD: MonoBehaviour
{
	[SerializeField] private Text[] txtItems;
	[SerializeField] private PickableFallingItem[] pickableFallingItems;
	[SerializeField] private GameObject[] lifes;
	[SerializeField] private FallingItemSpawner fallingItemSpawner;

	private void Start()
	{
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
		for (int j = 0; j < txtItems.Length; j++)
		{
			Text currentItemText = txtItems[j];
			if (currentItemText.name == itemName)
			{
				string text = currentItemText.text;
				int currentAmountCollected = (int)char.GetNumericValue(text[0]);
				int amountToCollect = (int)char.GetNumericValue(text[text.Length - 1]);
				if (currentAmountCollected < amountToCollect)
                {
					currentItemText.text = $"{currentAmountCollected + 1}{text.Substring(1)}";
				}
                
				if(currentAmountCollected + 1 == amountToCollect)
                {
					fallingItemSpawner.RemoveItemFromPool(itemName);
				}
			}
		}
	}

    private void InactiveHeart(int unused)
	{
		for(int i = lifes.Length - 1; i >= 0; i--){
            if (lifes[i].activeSelf)
            {
				lifes[i].SetActive(false);
				break;
			}
		}		
	}
}
