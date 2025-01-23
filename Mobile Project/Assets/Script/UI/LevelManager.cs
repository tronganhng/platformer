using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    void Start()
    {
        SetUpLevelsButton();
    }

    void SetUpLevelsButton()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i < GameData.instance.level)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
