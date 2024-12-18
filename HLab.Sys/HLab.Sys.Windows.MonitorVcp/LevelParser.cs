﻿using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace HLab.Sys.Windows.MonitorVcp;

public sealed class CommandWorker
{
    Task _task;
    readonly ConcurrentQueue<IWorkProvider> _actions = new();
    bool _stop = false;

    public void Enqueue(IWorkProvider level)
    {
        _actions.Enqueue(level);
        _task ??= Task.Run(DoWork);
    }

    void DoWork()
    {
        var doWork = true;
        while (doWork && !_stop)
        {
            if (_actions.TryDequeue(out var level))
            {
                level.DoWork();
            }
            else
            {
                doWork = false;
            }
        }

        while (_actions.TryDequeue(out var l))
        {
        }

        _task = null;
        _stop = false;
    }

    public void Stop()
    {
        _stop = true;
    }
}