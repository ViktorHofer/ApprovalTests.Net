using ApprovalUtilities.Persistence;
using ApprovalUtilities.SimpleLogger.Writers;

namespace ApprovalUtilities.SimpleLogger;

public static class Logger
{
    static LoggerInstance log = new();

    public static IAppendable Writer
    {
        get => log.Writer;
        set => log.Writer = value;
    }

    public static StringBuilderLogger LogToStringBuilder()
    {
        return log.LogToStringBuilder();
    }

    public static IDisposable MarkEntryPoints()
    {
        return new Marker(log);
    }

    public static string Event(string message, params object[] items)
    {
        return log.Event(message, items);
    }

    public static string Message(string message)
    {
        return log.Message(message);
    }

    public static void Variable(string name, object value)
    {
        log.Variable(name, value);
    }

    public static string Sql(string sql)
    {
        return log.Sql(sql);
    }

    public static string Miscellaneous(string label, string message)
    {
        return log.Miscellaneous(label, message);
    }

    public static void Warning(Exception exception, params string[] additional)
    {
        log.Warning(exception, additional);
    }

    public static string Warning(string format, params object[] data)
    {
        return log.Warning(format, data);
    }

    public static void Show(bool markerIn = true, bool variables = true, bool events = true, bool sql = true,
        bool timestamp = true, bool timeDifference = true)
    {
        log.Show(markerIn, variables, events, sql, timestamp, timeDifference);
    }

    public static void UseTimer(ILoader<DateTime> timeLoader)
    {
        log.UseTimer(timeLoader);
    }
    public static T Log<T>(this T t, string label, Func<T, string> log)
    {
        Variable(label, log(t));
        return t;
    }
}

public class Marker : IDisposable
{
    readonly LoggerInstance log;

    public Marker(LoggerInstance log)
    {
        this.log = log;
        log.MarkerIn();
    }

    public void Dispose()
    {
        log.MarkerOut();
    }
}