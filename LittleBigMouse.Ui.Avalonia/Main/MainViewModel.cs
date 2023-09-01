﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using DynamicData;
using DynamicData.Binding;
using HLab.Base.Avalonia.Extensions;
using HLab.Icons.Avalonia.Icons;
using HLab.Mvvm.Annotations;
using HLab.Mvvm.ReactiveUI;
using LittleBigMouse.DisplayLayout.Monitors;
using LittleBigMouse.Plugins;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace LittleBigMouse.Ui.Avalonia.Main;


public class MainViewModel : ViewModel, IMainViewModel, IMainPluginsViewModel
{
    public string Title => "Little Big Mouse";

    public MainViewModel(IIconService iconService, ILocalizationService localizationService)
    {
        IconService = iconService;
        LocalizationService = localizationService;
        CloseCommand = ReactiveCommand.Create(Close);

        _commandsCache.Connect()
            .Sort(SortExpressionComparer<UiCommand>.Ascending(t => t.Id))
            //.Filter(x => x.Id.ToString().EndsWith('1'))
            .Bind(out _commands)
            .Subscribe().DisposeWith(this);

        MaximizeCommand = ReactiveCommand.Create(() =>
            WindowState = WindowState != WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
    }

    public IIconService IconService { get; }
    public ILocalizationService LocalizationService { get; }

    public object? Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }
    object? _content = null;

    public Type ContentViewMode
    {
        get => _contentViewMode;
        set => this.RaiseAndSetIfChanged(ref _contentViewMode, value);
    }
    Type _contentViewMode = typeof(DefaultViewMode);

    public double VerticalResizerSize => 10.0;

    public double HorizontalResizerSize => 10.0;


    public ICommand CloseCommand { get; }
    //public ICommand CloseCommand { get; } = H.Command(c => c
    //    .Action(e => e.Close())
    //);

    public ICommand MaximizeCommand { get; }

    void Close()
    {
        //if (Layout?.Saved ?? true)
        //{
        //    // TODO : exit application
        //    return;
        //}

        var result = MessageBoxManager
            .GetMessageBoxStandard(
                "Save your changes before exiting ?",
                "Confirmation", ButtonEnum.OkCancel,
                Icon.Question, WindowStartupLocation.CenterOwner

                )
            //Todo get rid of Result
            .ShowAsync().Result;

        if (result == ButtonResult.Yes)
        {
            /* Todo avalonia*/
            //Layout.Save();
            
            //Application.Current.Shutdown();
        }

        if (result == ButtonResult.No)
        {
            //Application.Current.Shutdown();
        }
    }

    public WindowState WindowState
    {
        get => _windowState;
        set => this.RaiseAndSetIfChanged(ref _windowState, value);
    }
    WindowState _windowState;


    public void UnMaximize()
    {
        //var w = Application.Current.MainWindow;
        //if (w != null)
        WindowState = WindowState.Normal;
    }

    //readonly SourceCache<UiCommand, string> _commandsSource = new(c=>c.Id);
    readonly ReadOnlyObservableCollection<UiCommand> _commands;
    public ReadOnlyObservableCollection<UiCommand> Commands => _commands;

    SourceCache<UiCommand, string> _commandsCache { get; } = new(c => c.Id);

    public void AddButton(string id, string iconPath, string toolTipText, ICommand cmd)
    {
        var command = new UiCommand(id)
        {
            IconPath = iconPath,
            ToolTipText = toolTipText,
            Command = cmd,
        };

        _commandsCache.AddOrUpdate(command);

        //this.RaisePropertyChanged("Commands");
    }

}