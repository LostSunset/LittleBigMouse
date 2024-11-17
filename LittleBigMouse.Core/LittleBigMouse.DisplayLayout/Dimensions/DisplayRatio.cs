﻿/*
  LittleBigMouse.Screen.Config
  Copyright (c) 2021 Mathieu GRENET.  All right reserved.

  This file is part of LittleBigMouse.Screen.Config.

    LittleBigMouse.Screen.Config is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LittleBigMouse.Screen.Config is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MouseControl.  If not, see <http://www.gnu.org/licenses/>.

	  mailto:mathieu@mgth.fr
	  http://www.mgth.fr
*/

using System;
using System.Runtime.Serialization;
using HLab.Base;
using HLab.Base.ReactiveUI;
using LittleBigMouse.Zoning;

namespace LittleBigMouse.DisplayLayout.Dimensions;


public class BorderResistance : SavableReactiveModel, IBorderResistance
{
    public double Left 
    { 
        get => _left;
        set => SetUnsavedValue(ref _left,value); 
    }
    double _left;

    public double Top
    {
        get => _top;
        set => SetUnsavedValue(ref _top,value);
    }
    double _top;

    public double Right
    {
        get => _right;
        set => SetUnsavedValue(ref _right, value);
    }
    double _right;

    public double Bottom
    {
        get => _bottom;
        set => SetUnsavedValue(ref _bottom, value);
    }
    double _bottom;
}


public interface IDisplayRatio : ISavable
{
    double X { get; set; }
    double Y { get; set; }
    bool IsUnary { get; }
}

[DataContract]
public abstract class DisplayRatio : SavableReactiveModel, IDisplayRatio, IEquatable<IDisplayRatio>
{
    protected DisplayRatio() { }
    [DataMember]
    public abstract double X { get; set; }
    [DataMember]
    public abstract double Y { get; set; }

    public bool IsUnary => Math.Abs(X - 1) < double.Epsilon && Math.Abs(Y - 1) < double.Epsilon;

    public bool Equals(IDisplayRatio other)
    {
        if (other == null) return false;
        return !(Math.Abs(X - other.X) > double.Epsilon || Math.Abs(Y - other.Y) > double.Epsilon);
    }

    public override string ToString() => $"({X},{Y})";

}
