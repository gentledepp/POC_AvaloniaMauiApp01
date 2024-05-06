using System;
using Microsoft.Maui;

namespace Avalonia.Maui.Controls;

public class MauiGridLengthExtension
{
    private readonly double _value;
    private readonly GridUnitType _type;


    public MauiGridLengthExtension(double value, GridUnitType type)
    {
        _value = value;
        _type = type;
    }

    public Microsoft.Maui.GridLength ProvideValue(IServiceProvider provider)
    {
        return new Microsoft.Maui.GridLength(_value, _type);
    }
}