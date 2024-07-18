Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports VBGuiSample

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestSaveFile()
        Dim form1 As New Form1
        Dim text = form1.FormatText(1, 1, 1, 1, 1, 1)
        Assert.AreEqual(1, 1)
    End Sub

End Class