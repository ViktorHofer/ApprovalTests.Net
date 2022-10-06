[TestFixture]
// begin-snippet: multiple_reporters
[UseReporter(typeof(DiffReporter), typeof(FileLauncherReporter))]
// end-snippet:
public class HtmlTest
{
    [Test]
    public static void TestHtml()
    {
        Approvals.VerifyHtml("<html><body><div style='font-family:Broadway;font-size:18px'> Web Page from ApprovalTests</div></body></html>");
    }
}