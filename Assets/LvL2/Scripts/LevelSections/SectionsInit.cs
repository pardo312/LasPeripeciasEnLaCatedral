using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionsInit : MonoBehaviour
{
    private int arraysSize = 2;
    [SerializeField] private GameObject[] leftSections;
    [SerializeField] private GameObject[] noWallSections;
    [SerializeField] private GameObject[] rightSections;
    private bool alredyHasTop = false;
    private bool[] pathToExit;
    private int currentRow = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        pathToExit = new bool[9];
        GameObject[] currentSectionList = null;

        for(int i = 0; i<9;i++){
            int selectedSection = -1;
            //Asegura que solo haya una salida en cada fila.
            if(i%3==2)
            {
                if(!alredyHasTop)
                    selectedSection=0;
                else
                    selectedSection = Random.Range(1,arraysSize);
                    //Siguiente Fila
                alredyHasTop=false;
            }
            else{
                if(alredyHasTop)
                    selectedSection = Random.Range(1,arraysSize);
                else{
                    selectedSection = Random.Range(0,arraysSize);
                    if(selectedSection==0)
                        alredyHasTop=true;
                }
            } 
            int typeOfSection = 2;
            if(pathToExit[i])
                typeOfSection = Random.Range(1,4);
            switch (typeOfSection)
            {
                case 1:
                    currentSectionList = leftSections;
                    break;
                case 2:
                    currentSectionList = noWallSections;
                    break;
                case 3:
                    currentSectionList = rightSections;
                    break;
            }
            
            GameObject createdSection= Instantiate(currentSectionList[selectedSection],this.transform);
            createdSection.transform.position += new Vector3((i%3)*17,Mathf.FloorToInt((i/3))*-7,0);
        }
        
    }
}
