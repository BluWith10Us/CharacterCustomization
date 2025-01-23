using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeSwapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> hairStyle;
    [SerializeField] private List<GameObject> shirtStyle;
    [SerializeField] private List<GameObject> pantsStyle;

    private int hairIndex = 0;
    private int shirtIndex = 0;
    private int pantsIndex = 0;

    [SerializeField] Button hairFButton;
    [SerializeField] Button pantsFButton;
    [SerializeField] Button shirtFButton;
    [SerializeField] Button shirtBButton;
    [SerializeField] Button hairBButton;
    [SerializeField] Button pantsBButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure all styles are inactive, then activate defaults
        InitializeStyles(hairStyle, hairIndex);
        InitializeStyles(shirtStyle, shirtIndex);
        InitializeStyles(pantsStyle, pantsIndex);
        //Sets Buttons up
        hairFButton.onClick.AddListener(() => ChangeHair(1));
        hairBButton.onClick.AddListener(() => ChangeHair(-1));
        shirtFButton.onClick.AddListener(() => ChangeShirt(1));
        shirtBButton.onClick.AddListener(() => ChangeShirt(-1));
        pantsFButton.onClick.AddListener(() => ChangePants(1));
        pantsBButton.onClick.AddListener(() => ChangePants(-1));
        
    }

    public void ChangeHair(int direction)
    {
        hairIndex = SetActiveStyle(hairIndex, direction, hairStyle);
    }

    public void ChangeShirt(int direction)
    {
        shirtIndex = SetActiveStyle(shirtIndex, direction, shirtStyle);
    }

    public void ChangePants(int direction)
    {
        pantsIndex = SetActiveStyle(pantsIndex, direction, pantsStyle);
    }

    // Sets up the active style for a specific category
    private void InitializeStyles(List<GameObject> styles, int defaultIndex)
    {
        for (int i = 0; i < styles.Count; i++)
        {
            if (styles[i] != null)
            {
                styles[i].SetActive(i == defaultIndex);
            }
        }
    }

    // Changes the active style, deactivates the old one, and activates the new one
    private int SetActiveStyle(int currentIndex, int direction, List<GameObject> styles)
    {
        if (styles == null || styles.Count == 0) return currentIndex;

        // Deactivate the current style
        if (styles[currentIndex] != null)
        {
            styles[currentIndex].SetActive(false);
        }

        // Update the index
        currentIndex = (currentIndex + direction + styles.Count) % styles.Count;

        // Activate the new style
        if (styles[currentIndex] != null)
        {
            styles[currentIndex].SetActive(true);
        }

        return currentIndex;
    }
}
