﻿using System;
using UnityEngine;

namespace ShortCuts.Tabs;

public static class LaunchPad
{
        
    private static float _lastTimeClicked = 0;
    private const float Threshold = 0.5f;
    private const bool MultipleInRow = false;

        
    public static void AddListener()
    {
        UI.LaunchPadTabButton.onClick.AddListener(new Action(() =>
        {
            var doubleClick = IsDoubleClick();
            if (doubleClick)
            {
                Actions.DoubleClickHandler(Main.LaunchPadAction.Value);
            }

        }));
    }
        
    //Thank you Psychloor for this helpful function!
    private static bool IsDoubleClick()
    {
        if (_lastTimeClicked == 0)
        {
            _lastTimeClicked = Time.time;
            return false;
        }
        if (Time.time - _lastTimeClicked <= Threshold)
        {
            _lastTimeClicked = MultipleInRow ? Time.time : Threshold * 2f;
            return true;
        }
        _lastTimeClicked = Time.time;
        return false;
    }
}