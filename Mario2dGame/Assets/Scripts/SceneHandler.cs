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

    private int startMenuScreen = 0;
    private int endGameScreen = 1;
    private int settingsScreen = 2;
    private int levelOne = 3;
    private int levelTwo = 4;
    private int levelThree = 5;
    private int MapScene1 = 6;

    // Jump to start screen
    public void goToStartScreen()
    {
        SceneManager.LoadScene(startMenuScreen);
    }

    // Jump to first level
    public void goToLevelOne()
    {
        SceneManager.LoadScene(levelOne);
    }

    // Jump to first level
    public void goToLevelTwo()
    {
        SceneManager.LoadScene(levelTwo);
    }

    // Jump to first level
    public void goToLevelThree()
    {
        SceneManager.LoadScene(levelThree);
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
        SceneManager.LoadScene(endGameScreen);
    }

    // Jump to next scene
    public void jumpToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Restart the game.
    public void restartGameScene() 
    {
        SceneManager.LoadScene(levelOne);
    }

    // Restart the level
    public void restartLevelScene()
    {
        int lastScene = PlayerPrefs.GetInt("restartlevelat");

        if(lastScene > 0 && lastScene != -1)
        {
            SceneManager.LoadScene(lastScene);
        } else
        {
            Debug.Log("Scene not found");
            Debug.Log(lastScene);
        }
    }

    // Script to handle menu scene.
    public void menuHandler()
    {
        int getCurrentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Current Scene", getCurrentScene);
        SceneManager.LoadScene(0);
    }

    // Functions for development and testing purposes and not for production purpose.
    public void devJumpToEndGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("restartlevelat", currentSceneIndex);
        goToEndGame();
    }

    public void goToSettings()
    {
        SceneManager.LoadScene(settingsScreen);
    }

    public void goToLevelSelector()
    {
        SceneManager.LoadScene(MapScene1);
    }

}
