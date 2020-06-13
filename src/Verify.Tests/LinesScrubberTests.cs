﻿using System;
using System.Threading.Tasks;
using Verify;
using VerifyXunit;
using Xunit;

[InjectInfo]
public class LinesScrubberTests
{
    [Fact]
    public Task ScrubLinesContaining()
    {
        var settings = new VerifySettings();
        settings.ScrubLinesContaining("c", "D", "F");
        return Verifier.Verify(
            settings: settings,
            target: @"a
b
c
D
e
f");
    }

    [Fact]
    public Task DontScrubTrailingNewline()
    {
        var settings = new VerifySettings();
        settings.ScrubLines(removeLine: x => x.Contains("D"));
        return Verifier.Verify(
            settings: settings,
            target:  @"b
");
    }

    [Fact]
    public Task DontScrubMultiNewline()
    {
        var settings = new VerifySettings();
        settings.ScrubLines(removeLine: x => x.Contains("D"));
        return Verifier.Verify(
            settings: settings,
            target:  @"b

c");
    }

    [Fact]
    public Task FilterLines()
    {
        var settings = new VerifySettings();
        settings.ScrubLines(removeLine: x => x.Contains("D"));
        return Verifier.Verify(
            settings: settings,
            target:  @"a
b
c
D
e
f");
    }

    [Fact]
    public Task ScrubLinesContaining_case_sensitive()
    {
        var settings = new VerifySettings();
        settings.ScrubLinesContaining(StringComparison.Ordinal, "c", "D", "F");
        return Verifier.Verify(
            settings: settings,
            target: @"a
b
c
D
e
f");
    }
}