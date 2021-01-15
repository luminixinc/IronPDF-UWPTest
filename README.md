# IronPDF-UWPTest

This Visual Studio 2019 solution contains 2 projects:

- PDFPrinterLib (.NET Standard 2.0 project) that uses the IronPdf NuGet package v2020.12.3
- IronPDF-UWPTest (Universal Windows project) that calls PDFPrinterLib to print a simple "Hello World" PDF

## Issue building Release version of Universal Windows (UWP) app with IronPdf (v2020.12.3) for .NET Standard

This VS solution showcases a problem with building against IronPdf in `Release` Configuration.

In particular the UWP app builds and runs only with `Debug|x64` and `Debug|x86` Configuration|Platform variants.  When attempting to build the `Release` Configuration for `x64` and `x86` Platforms, compilation aborts with an internal compiler error (`Release|x86` shown):

```
Severity	Code	Description	Project	File	Line	Suppression State
Error		ILT0005: 'C:\Program Files (x86)\Microsoft SDKs\UWPNuGetPackages\runtime.win10-x86.microsoft.net.native.compiler\2.2.8-rel-28605-00\tools\x86\ilc\Tools\nutc_driver.exe @"C:\luminix\IronPDF-UWPTest\IronPDF-UWPTest\obj\x86\Release\ilc\intermediate\MDIL\IronPDF-UWPTest.rsp"' returned exit code 1	IronPDF-UWPTest

Error		Error: NUTC3039:Internal Compiler Error: Field 'hjxxbx' on type 'IronPdf.Extensions.tmlcqv+isbgpb' from assembly 'IronPdf' is a byref-like field that is not defined on a byref-like type while loading type 'IronPdf.Extensions.tmlcqv+isbgpb'. while computing compilation roots.	IronPDF-UWPTest
```
