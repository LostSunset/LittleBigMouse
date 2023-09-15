﻿using HLab.Core.Annotations;
using LittleBigMouse.Plugins;
using LittleBigMouse.Plugins.Avalonia;

namespace LittleBigMouse.Plugin.Layout.Avalonia.LocationPlugin;

public class MonitorLocationPlugin(IMainService mainService) : IBootloader
{
    public void Load(IBootContext bootstrapper)
    {
        mainService.AddControlPlugin(c =>
            c.AddViewModeButton<MonitorLocationViewMode>(
                "location",
                "Icon/MonitorLocation",
                "Location"

        ));
    }

}