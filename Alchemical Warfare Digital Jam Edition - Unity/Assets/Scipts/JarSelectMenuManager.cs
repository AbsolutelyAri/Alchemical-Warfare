/*
 * Manages the player jar selection menu and passes jar data to the appropriate managers
 * 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JarSelectMenuManager : MonoBehaviour
{
    /*****VARIABLES*****/
    
    public int maxJars = 6; //Most jars the player can select
    public int jarTypes = 3; //Number of types of jars
    public int maxJarsPerType = 3; //Most jars of a single type the player can select
    public TMP_Text[] jarCountTexts; //UI text boxes displaying how many jars of each type 

    private int totalJarsSelected = 0;
    private int[] jarCounts;

    // Start is called before the first frame update
    void Start()
    {
        jarCounts = new int[jarTypes];

        for(int j = 0; j < jarTypes; j++)
        {
            jarCounts[j] = 0;
            UpdateJarCountText(j);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Adds a jar of a selected type
    public void AddJar(int jarIndex)
    {
        if(totalJarsSelected < maxJars && jarCounts[jarIndex] < maxJarsPerType)
        {
            jarCounts[jarIndex]++;
            UpdateJarCountText(jarIndex);
            totalJarsSelected++;
        }
    }

    // Removes a jar of a selected type
    public void RemoveJar(int jarIndex)
    {
        if (jarCounts[jarIndex] > 0)
        {
            jarCounts[jarIndex]--;
            UpdateJarCountText(jarIndex);
            totalJarsSelected--;
        }
    }

    //Updates the textbox corresponding to jarindex with the jar count stored in the jarCounts array
    private void UpdateJarCountText(int jarIndex)
    {
        if(jarIndex < jarCountTexts.Length)
        {
            jarCountTexts[jarIndex].text = jarCounts[jarIndex].ToString();
        }
    }
}
