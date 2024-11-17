﻿
using System;
using Avalonia;
using HLab.Base;

namespace LittleBigMouse.DisplayLayout.Dimensions;

public interface IDisplaySize : IEquatable<IDisplaySize>, ISavable
{
    IDisposable DelayChangeNotifications();

    double Width { get; set; }
    double Height { get; set; }
    double X { get; set; }
    double Y { get; set; }
    double TopBorder { get; set; }
    double BottomBorder { get; set; }
    double LeftBorder { get; set; }
    double RightBorder { get; set; }

    Rect Bounds { get; }
    Point Center { get; }

    Rect OutsideBounds { get; }
    double OutsideWidth { get; }
    double OutsideHeight { get; }
    double OutsideX { get; }
    double OutsideY { get; }

    Point Location { get; }
}
