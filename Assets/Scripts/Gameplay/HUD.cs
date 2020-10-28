using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD: MonoBehaviour
{
	private GameObject corazon;

	[SerializeField]
	private Text txtCincel;
	[SerializeField]
	private Text txtPincel;
	[SerializeField]
	private Text txtHisopo;
	[SerializeField]
	private Text txtGuantes;
	[SerializeField]
	private Text txtCepillo;
	[SerializeField]
	private Text txtEstatua;

	[SerializeField]
	public GameObject[] lifes;

	private static PickableFallingItem[] pickableFallingItems;

	private void Start()
    {
		pickableFallingItems = FallingItemSpawner.PickableFallingItems;
		for(int i = 0; i < pickableFallingItems.Length; i ++)
        {
			PickableFallingItem currentPickableFallingItem = pickableFallingItems[i];
			string currenItemAmountToCollect = currentPickableFallingItem.amountToCollect.ToString();
			if (currentPickableFallingItem.name == "Cepillo")
            {
				txtCepillo.text = currenItemAmountToCollect;
			}
			else if (currentPickableFallingItem.name == "Cincel")
			{
				txtCincel.text = currenItemAmountToCollect;
			}
			else if (currentPickableFallingItem.name == "Estatua")
			{
				txtEstatua.text = currenItemAmountToCollect;
			}
			else if (currentPickableFallingItem.name == "Guantes")
			{
				txtGuantes.text = currenItemAmountToCollect;
			}
			else if (currentPickableFallingItem.name == "Isopo")
			{
				txtHisopo.text = currenItemAmountToCollect;
			}
			else if (currentPickableFallingItem.name == "Pincel")
			{
				txtPincel.text = currenItemAmountToCollect;
			}

		}
	}

	public void CollectItem(string itemName)
    {
		Text textToChange = null;

		if (itemName == "Cepillo")
		{
			textToChange = txtCepillo;
		}
		else if (itemName == "Cincel")
		{
			textToChange = txtCincel;
		}
		else if (itemName == "Estatua")
		{
			textToChange = txtEstatua;
		}
		else if (itemName == "Guantes")
		{
			textToChange = txtGuantes;
		}
		else if (itemName == "Isopo")
		{
			textToChange = txtHisopo;
		}
		else if (itemName == "Pincel")
		{
			textToChange = txtPincel;
		}

        if (textToChange)
        {
			textToChange.text = (int.Parse(textToChange.text) - 1).ToString();
		}
	}


    private void OnTriggerEnter2D(Collider2D collider){
		  //collider.gameObject.tag == "piedra" //si tiene tag
		if (collider.gameObject.name == "piedra") 
        {
			for(int i=1;i<4;i++){
				corazon = GameObject.Find("corazon_" + i);
				if(corazon!=null){
					Debug.Log(corazon.name);
					corazon.SetActive(false);
					break;
				}
					
			}
		}
	}
}
