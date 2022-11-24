using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelMenuHandler : MonoBehaviour
{
    public Button Level1;
    public Button Level2;
    public Button Level3;
    private int lastVisitedLevel;

    void Start()
    {
        Debug.Log("start!");
        lastVisitedLevel = PlayerPrefs.GetInt("lastvisitedlevel");

        Debug.Log("lastVisitedLevel: ");
        Debug.Log(lastVisitedLevel);
        Level2.interactable = false;
        Level2.interactable = lastVisitedLevel == 4 ? true : false;
        Level3.interactable = lastVisitedLevel == 5 ? true : false;

    }

    public void visitLevelOne ()
    {
        if(Level1.interactable)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void visitLevelTwo ()
    {
        if(Level2.interactable)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void visitLevelThree()
    {
        if (Level3.interactable)
        {
            SceneManager.LoadScene(5);
        }
    }
}
