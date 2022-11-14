using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    /*
     * DISCLAIMER:
     * 
     * This file handles all the scenes. 
     * The jumps to the scenes is handled by the 
     *      order of index of the scenes present in the Project Settings.
     * Make sure when you introduce the index number for the scene jump
     *      it is in the same order as the one in Project Settings.
     *
     */

    // Jump to start screen
    public void goToStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    // Jump to first level
    public void goToLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    // Jump to first level
    public void goToLevelTwo()
    {
        // SceneManager.LoadScene(1);
    }

    // Jump to first level
    public void goToLevelThree()
    {
        // SceneManager.LoadScene(1);
    }

    /*
     * Jump to the End Scene
     * 
     * When adding new scenes, make sure to order the scenes in the Project settings
     * and add the proper index number in the Load Scene index value.
     * 
     */
    public void goToEndGame()
    {
        SceneManager.LoadScene(2);
    }

    // Jump to next scene
    public void jumpToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Restart the game.
    public void restartGameScene() 
    {

    }

    // Restart the level
    public void restartLevelScene()
    {

    }
}
