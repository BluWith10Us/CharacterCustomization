using UnityEngine;
using UnityEngine.UI;

public class GenderSwapper : MonoBehaviour
{
    GameObject currentMode;
    [SerializeField] GameObject maleModel, femaleModel;
    [SerializeField] Button genderButton;

    [SerializeField]
    Button[] maleButtons, femaleButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maleModel.SetActive(true);
        femaleModel.SetActive(false);
        currentMode = maleModel;

        genderButton.onClick.AddListener(ChangeGender);
    }

    void ChangeGender()
    {
        if (currentMode == maleModel)
        {
            currentMode.SetActive(false);
            currentMode = femaleModel;
            currentMode.SetActive(true);
            for (int i = 0; i < maleButtons.Length; i++)
            {
                maleButtons[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < femaleButtons.Length; i++)
            {
                femaleButtons[i].gameObject.SetActive(true);
            }

        } else if (currentMode == femaleModel)
        {
            currentMode.SetActive(false);
            currentMode = maleModel;
            currentMode.SetActive(true);
            for (int i = 0; i < femaleButtons.Length; i++)
            {
                femaleButtons[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < maleButtons.Length; i++)
            {
                maleButtons[i].gameObject.SetActive(true);
            }
        }

        
    }
}
