using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : SingletonData<ScreenManager>
{
    public int width => Screen.width;
    public int height => Screen.height;
    public bool fullScreen;
    private Resolution[] resolutions => Screen.resolutions;
    public List<Resolution> resolutionList;

    protected override void OnInit()
    {
        this.fullScreen = Screen.fullScreen;
        this.resolutionList = new List<Resolution>();
        foreach (var resolution in this.resolutions) {
            this.resolutionList.Add(resolution);
        }
    }

    public void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, fullScreen);
    }

    public void setFullScreen(bool value)
    {
        this.fullScreen = value;
        Screen.SetResolution(this.width, this.height, this.fullScreen);
    }
}
