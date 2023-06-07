using System.Net.Sockets;
using Server.RequestHandlers;
using Shared;

namespace Server;

public static class RequestHandlersProvider
{
    private static Dictionary<string, RequestHandler> Handlers { get; } = new();

    static RequestHandlersProvider()
    {
        var types = typeof(RequestHandler).Assembly.GetTypes().Where(t => t.BaseType == typeof(RequestHandler));

        Handlers.Clear();

        foreach (var type in types)
        {
            var info = type.GetConstructor(Type.EmptyTypes);

            if (info == null) continue;

            var command = (RequestHandler) info.Invoke(null);

            Handlers.Add(type.Name.Replace("RequestHandler", "").ToLower(), command);
        }
    }

    public static void Add(string name, RequestHandler handler)
    {
        Handlers.Add(name, handler);
    }

    public static void Remove(string name)
    {
        Handlers.Remove(name);
    }

    public static bool HasHandler(string name)
    {
        return Handlers.ContainsKey(name);
    }

    public static RequestHandler? GetHandler(string name)
    {
        return HasHandler(name) ? Handlers[name] : null;
    }

    public static Dictionary<string, RequestHandler>.KeyCollection GetHandlerNames() => Handlers.Keys;

    public static void Handle(TcpClient client, Request request, RequestHandler defaultHandler)
    {
        var handler = GetHandler(request.Action.ToLower()) ?? defaultHandler;

        handler.Handle(client, request);
    }
}