using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapViewHandler : MonoBehaviour
{
    [SerializeField] GameObject Controls;
    [SerializeField] GameObject MinimapPanel;
    [SerializeField] GameObject PlayerObject;

    public void enableMiniMap ()
    {
        Controls.SetActive(false);
        MinimapPanel.SetActive(true);
        PlayerObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void disableMiniMap ()
    {
        Controls.SetActive(true);
        MinimapPanel.SetActive(false);
        PlayerObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
