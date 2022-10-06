namespace ApprovalTests.Reporters;

public class FrontLoadedReporterDisposer : IDisposable
{
    public static IEnvironmentAwareReporter Default = DefaultFrontLoaderReporter.INSTANCE;
    readonly IEnvironmentAwareReporter previous;

    public FrontLoadedReporterDisposer(IEnvironmentAwareReporter reporter)
    {
        previous = Default;
        Default = reporter;
    }

    public void Dispose()
    {
        Default = previous;
    }
}