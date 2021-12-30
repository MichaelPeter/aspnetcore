// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Components.RenderTree;

public abstract partial class Renderer
{
    internal static partial class Log
    {
        [LoggerMessage(1, LogLevel.Debug, "Initializing component {ComponentId} ({ComponentType}) as child of {ParentComponentId} ({ParentComponentType})", EventName = "InitializingChildComponent", SkipEnabledCheck = true)]
        private static partial void InitializingChildComponent(ILogger logger, int componentId, Type componentType, int parentComponentId, Type parentComponentType);

        [LoggerMessage(2, LogLevel.Debug, "Initializing root component {ComponentId} ({ComponentType})", EventName = "InitializingRootComponent", SkipEnabledCheck = true)]
        private static partial void InitializingRootComponent(ILogger logger, int componentId, Type componentType);

        public static void InitializingComponent(ILogger logger, ComponentState componentState, ComponentState parentComponentState)
        {
            if (logger.IsEnabled(LogLevel.Debug)) // This is almost always false, so skip the evaluations
            {
                if (parentComponentState == null)
                {
                    InitializingRootComponent(logger, componentState.ComponentId, componentState.Component.GetType());
                }
                else
                {
                    InitializingChildComponent(logger, componentState.ComponentId, componentState.Component.GetType(), parentComponentState.ComponentId, parentComponentState.Component.GetType());
                }
            }
        }

        [LoggerMessage(3, LogLevel.Debug, "Rendering component {ComponentId} of type {ComponentType}", EventName = "RenderingComponent", SkipEnabledCheck = true)]
        private static partial void RenderingComponent(ILogger logger, int componentId, Type componentType);

        public static void RenderingComponent(ILogger logger, ComponentState componentState)
        {
            RenderingComponent(logger, componentState.ComponentId, componentState.Component.GetType());
        }

        [LoggerMessage(4, LogLevel.Debug, "Disposing component {ComponentId} of type {ComponentType}", EventName = "DisposingComponent", SkipEnabledCheck = true)]
        private static partial void DisposingComponent(ILogger<Renderer> logger, int componentId, Type componentType);

        public static void DisposingComponent(ILogger<Renderer> logger, ComponentState componentState)
        {
            if (logger.IsEnabled(LogLevel.Debug)) // This is almost always false, so skip the evaluations
            {
                DisposingComponent(logger, componentState.ComponentId, componentState.Component.GetType());
            }
        }

        [LoggerMessage(5, LogLevel.Debug, "Handling event {EventId} of type '{EventType}' for component '{ComponentId}'", EventName = "HandlingEvent", SkipEnabledCheck = true)]
        private static partial void HandlingEvent(ILogger<Renderer> logger, ulong eventId, string eventType, string componentId);

        public static void HandlingEvent(ILogger<Renderer> logger, ulong eventHandlerId, EventArgs? eventArgs, int? componentId)
        {
            if (logger.IsEnabled(LogLevel.Debug)) // This is almost always false, so skip the evaluations
            {
                HandlingEvent(logger, eventHandlerId, eventArgs?.GetType().Name ?? "null", componentId?.ToString(System.Globalization.CultureInfo.InvariantCulture) ?? "null");
            }
        }

        // These logs got added later thats why the eventIds are higher

        [LoggerMessage(6, LogLevel.Debug, "Rendered component {ComponentId} of type {ComponentType}", EventName = "RenderingComponent", SkipEnabledCheck = true)]
        private static partial void RenderedComponent(ILogger logger, int componentId, Type componentType);

        public static void RenderedComponent(ILogger logger, ComponentState componentState)
        {
            RenderedComponent(logger, componentState.ComponentId, componentState.Component.GetType());
        }

        [LoggerMessage(7, LogLevel.Debug, "Initializing and setting parameters for component {ComponentId} of type {ComponentType}", EventName = "RenderedComponent", SkipEnabledCheck = true)]
        private static partial void InitializingAndSettingParametersComponent(ILogger logger, int componentId, Type componentType);

        public static void InitializingAndSettingParametersComponent(ILogger logger, ComponentState componentState)
        {
            InitializingAndSettingParametersComponent(logger, componentState.ComponentId, componentState.Component.GetType());
        }

        [LoggerMessage(8, LogLevel.Debug, "Setting parameters for component {ComponentId} of type {ComponentType}", EventName = "RenderedComponent", SkipEnabledCheck = true)]
        private static partial void SettingParametersComponent(ILogger logger, int componentId, Type componentType);

        public static void SettingParametersComponent(ILogger logger, ComponentState componentState)
        {
            SettingParametersComponent(logger, componentState.ComponentId, componentState.Component.GetType());
        }

        [LoggerMessage(9, LogLevel.Debug, "AfterRender completed for component {ComponentId} of type {ComponentType}", EventName = "RenderedComponent", SkipEnabledCheck = true)]
        private static partial void AfterRenderCompleteComponent(ILogger logger, int componentId, Type componentType);

        public static void AfterRenderCompleteComponent(ILogger logger, ComponentState componentState)
        {
            if (logger.IsEnabled(LogLevel.Debug)) // This is almost always false, so skip the evaluations
            {
                AfterRenderCompleteComponent(logger, componentState.ComponentId, componentState.Component.GetType());
            }
        }
    }
}
