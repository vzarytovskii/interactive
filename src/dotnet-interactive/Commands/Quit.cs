﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using System;
using System.Threading.Tasks;
using Microsoft.DotNet.Interactive.Commands;

namespace Microsoft.DotNet.Interactive.App.Commands
{
    public class Quit : KernelCommandBase
    {

        public Quit(Action onQuit = null, string targetKernelName = null): base(targetKernelName)
        {
            onQuit ??= DefaultOnQuit ??(() =>
            {
                Environment.Exit(0);
            });

            Handler = (command, context) =>
            {
                context.Complete(context.Command);
                onQuit();
                return Task.CompletedTask;
            };
        }

        internal static Action DefaultOnQuit { get; set; }
    }
}