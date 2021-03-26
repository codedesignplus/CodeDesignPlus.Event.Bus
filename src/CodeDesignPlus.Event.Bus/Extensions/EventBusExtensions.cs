using CodeDesignPlus.Core.Abstractions;
using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Internal.EventBusBackgroundService;
using CodeDesignPlus.Event.Bus.Internal.Queue;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace CodeDesignPlus.Event.Bus.Extensions
{
    /// <summary>
    /// Extension methods for adding events handler to an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    /// </summary>
    public static class EventBusExtensions
    {
        /// <summary>
        /// Adds the services of the type <see cref="IEventBus"/> and <see cref="ISubscriptionManager"/>
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            services.AddSingleton<ISubscriptionManager, SubscriptionManager>();

            var eventBus = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).FirstOrDefault(x => typeof(IEventBus).IsAssignableFrom(x));

            services.AddSingleton(typeof(IEventBus), eventBus);

            return services;
        }

        /// <summary>
        /// Adds the event handlers that implement the CodeDesignPlus.Event.Bus.Abstractions.IEventHandler interface and subscribe in ISuscriptionManager
        /// </summary>
        /// <typeparam name="TStartupLogic">Implementation of the IStartupServices type</typeparam>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddEventsHandlers<TStartupLogic>(this IServiceCollection services)
            where TStartupLogic : IStartupServices
        {
            services.AddEventHandler<TStartupLogic>();
            services.SubscribeEvents<TStartupLogic>();

            return services;
        }

        /// <summary>
        /// Adds the event handlers that implement the CodeDesignPlus.Event.Bus.Abstractions.IEventHandler interface
        /// </summary>
        /// <typeparam name="TStartupLogic">Implementation of the IStartupServices type</typeparam>
        /// <param name="services">A reference to this instance after the operation has completed.</param>
        private static IServiceCollection AddEventHandler<TStartupLogic>(this IServiceCollection services)
            where TStartupLogic : IStartupServices
        {
            var typeInterface = typeof(IEventHandler<>);

            var eventsHandlers = Assembly.GetAssembly(typeof(TStartupLogic)).GetTypes().Where(x => typeInterface.IsAssignableFrom(x));

            foreach (var eventHandler in eventsHandlers)
            {
                var interfaceEventHandlerGeneric = eventHandler.GetInterfaces().FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEventHandler<>));
                var eventType = interfaceEventHandlerGeneric?.GetGenericArguments().FirstOrDefault(x => x.IsClass && !x.IsAbstract && !x.IsSubclassOf(typeof(EventBase)));

                if (interfaceEventHandlerGeneric != null && eventType != null)
                {
                    var queueServiceType = typeof(IQueueService<,>).MakeGenericType(interfaceEventHandlerGeneric, eventType);
                    var queueServiceImplementationType = typeof(QueueService<,>).MakeGenericType(interfaceEventHandlerGeneric, eventType);

                    var hostServiceType = typeof(IEventBusBackgroundService<,,>).MakeGenericType(queueServiceType, interfaceEventHandlerGeneric, eventType);
                    var hostServiceImplementationType = typeof(EventBusBackgroundService<,,>).MakeGenericType(queueServiceType, interfaceEventHandlerGeneric, eventType);

                    services.AddSingleton(queueServiceType, queueServiceImplementationType);
                    services.AddTransient(hostServiceType, hostServiceImplementationType);
                    services.AddTransient(eventHandler);
                }
            }

            return services;
        }

        /// <summary>
        /// Subscribe all implementation of the type IEventHandler
        /// </summary>
        /// <typeparam name="TStartupLogic">Implementation of the IStartupServices type</typeparam>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        private static IServiceCollection SubscribeEvents<TStartupLogic>(this IServiceCollection services)
            where TStartupLogic : IStartupServices
        {
            var eventBus = services.BuildServiceProvider().GetRequiredService<IEventBus>();

            var typeEventBus = eventBus.GetType();

            var typeInterface = typeof(IEventHandler<>);

            var eventsHandlers = Assembly.GetAssembly(typeof(TStartupLogic)).GetTypes().Where(x => typeInterface.IsAssignableFrom(x));

            foreach (var eventHandler in eventsHandlers)
            {
                var interfaceEventHandlerGeneric = eventHandler.GetInterfaces().FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEventHandler<>));

                if (interfaceEventHandlerGeneric != null)
                {
                    var member = interfaceEventHandlerGeneric.GetGenericArguments().FirstOrDefault(x => x.IsSubclassOf(typeof(EventBase)));

                    if (!member.IsGenericParameter)
                    {
                        var methodSuscribe = typeEventBus.GetMethods().FirstOrDefault(x => x.Name == nameof(IEventBus.SubscribeAsync) && x.IsGenericMethod);

                        var methodGeneric = methodSuscribe.MakeGenericMethod(member, eventHandler);

                        methodGeneric.Invoke(eventBus, null);
                    }
                }
            }

            return services;
        }
    }
}
