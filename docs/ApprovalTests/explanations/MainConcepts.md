<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/ApprovalTests/explanations/mdsource/MainConcepts.source.md
To change this file edit the source file and then execute run_markdown.cmd.
-->

# Main Concepts in ApprovalTests

<!-- toc -->
## Contents

  * [Verify](#verify)
  * [Writers](#writers)
  * [Namers](#namers)
  * [Reporters](#reporters)
  * [Approval Output Files](#approval-output-files)<!-- endtoc -->

## Verify
The entry point to ApprovalTests is almost always some variation of a [Verify method](../Verify.md).

For example: 
<!-- snippet: simple_verify -->
<a id='snippet-simple_verify'/></a>
```cs
[Test]
public void Text()
{
    Approvals.Verify("should be approved");
}
```
<sup><a href='/src/ApprovalTests.Tests/ApprovalsTest.cs#L13-L19' title='File snippet `simple_verify` was extracted from'>snippet source</a> | <a href='#snippet-simple_verify' title='Navigate to start of snippet `simple_verify`'>anchor</a></sup>
<!-- endsnippet -->

This call brings together 3 things + default Approver to produce a `.received.` file which is a compared to an `.approved.` file.

![](MainConceptsSimplified.svg)

**Note:** This is a simplified version of what ApprovalTests does. You can see a [full picture here](MainConceptsComplete.svg)

## Writers
[Writers](https://github.com/approvals/ApprovalTests.Net/blob/master/src/ApprovalTests/Core/IApprovalWriter.cs) are responsible for writing the `.received.` file to the disc.
They also determine the extension for both `.received.` and `.approved.` files.

The text writer is most commonly used. But there also exist binary writers for things such as images and pdf files. It is rare to have to create one of these and most of the time they are chosen by an underlying `Verify()` function. 

## Namers
[Namers](https://github.com/approvals/ApprovalTests.Net/blob/master/src/ApprovalTests/Core/IApprovalNamer.cs) are responsible for figuring out what the file should be called and where it is located.
They primarily do this by inspecting a stack trace to detect your test frameworks' attributes.

The only reason you will want to create a Namer on your own is to support a new testing framework.

## Reporters
[Reporters](https://github.com/approvals/ApprovalTests.Net/blob/master/src/ApprovalTests/Core/IApprovalReporter.cs) are called only on failure.
They are responsible for such as opening Diff tools, copying commands to your clipboard or anything else that can help you determine what went wrong and fix it. 

It is very common to switch between Reporters for both personal preferences(a preferred Diff tool) and contextual preferences(at this moment I want to...).
There is also a chance you will create your own custom Reporter to support a tool you like or change the order in which Diff tools are selected.
Because using a right Reporter at the right time is so important, there are multiple places they can be configured, including which is Reporter is default Reporter.

## Approval Output Files
The core of Approvals is that your result and expectations are saved in output files.
Actual: `ClassName.TestMethodName.received.txt`
Expected: `ClassName.TestMethodName.approved.txt`

The actual files (`.recieved.`) are deleted on success and should never be checked on your source control.
The expected files (`.approved.`) need to be checked into your source control.

---

[Back to User Guide](../readme.md#top)