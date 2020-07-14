using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public GameObject PanelBuild;
    public GameObject PanelTec;

    public void OpenPanelBuild()
    {
        if (PanelBuild != null)
        {
            PanelBuild.SetActive(true);
            PanelTec.SetActive(false);
        }
    }

    public void OpenPanelTec()
    {
        if (PanelTec != null)
        {
            PanelTec.SetActive(true);
            PanelBuild.SetActive(false);
        }
    }

    public void CloseAllPanels()
    {
        PanelTec.SetActive(false);
        PanelBuild.SetActive(false);
    }


}
