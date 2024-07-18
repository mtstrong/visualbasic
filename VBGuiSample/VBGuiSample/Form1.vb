Imports System.IO

Public Class Form1

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DebugLog("Application Launching")
        Reset()
    End Sub

    Protected Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        DebugLog("User Clicked Save Button")
        'leaving a defect in here on purpose'
        Dim textToSave = FormatText(TextBox1.Text, TextBox2.Text, 0.04, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        SaveOutputFile(textToSave)
    End Sub

    Protected Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        DebugLog("User Clicked Reset Button")
        Reset()
    End Sub

    Protected Sub NewFeatureButton_Click(sender As Object, e As EventArgs) Handles TbdButton.Click
        DebugLog("User Clicked New Feature Button")
        My.Application.Log.WriteEntry("Reset Button Clicked", TraceEventType.Information)
        MessageBox.Show("This feature is not implemented yet...")
    End Sub

    Public Function FormatText(value1 As String, value2 As String, value3 As String, value4 As String, value5 As String, value6 As String) As String
        Dim textToSave = String.Format("{0}{6}{1}{6}{2}{6}{3}{6}{4}{6}{5}", value1, value2, value3, value4, value5, value6, Environment.NewLine)
        Return textToSave
    End Function

    Private Sub SaveOutputFile(text As String)
        Dim outputFile = "C:\temp\output.txt"
        If System.IO.File.Exists(outputFile) = True Then
            System.IO.File.Delete(outputFile)
        End If
        Using sw As New StreamWriter(File.Open(outputFile, FileMode.Create))
            sw.Write(text)
        End Using
        MessageBox.Show(String.Format("Output saved to {0}", outputFile))
    End Sub

    Public Sub DebugLog(text As String)
        Dim textPlusDateTime = String.Format("{0} - {1}", DateTime.Now, text)
        Dim logFile As String = "c:\temp\logfile.txt"
        Dim fileExists As Boolean = File.Exists(logFile)
        If System.IO.File.Exists(logFile) = True Then
            Using sw As StreamWriter = File.AppendText(logFile)
                sw.WriteLine(textPlusDateTime)
            End Using
        Else
            Using sw As New StreamWriter(File.Open(logFile, FileMode.OpenOrCreate))
                sw.WriteLine(textPlusDateTime)
            End Using
        End If
    End Sub

    Private Sub Reset()
        TextBox1.Text = "0.0000"
        TextBox2.Text = "0.0000"
        TextBox3.Text = "0.0000"
        TextBox4.Text = "0.0000"
        TextBox5.Text = "0.0000"
        TextBox6.Text = "0.0000"
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'Do not allow letters to be entered'
        If Not Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'Format it as 4 decimal places eventually....'
        'TextBox1.Text = Format(TextBox1.Text, "0.0000")'
    End Sub

    'todo add these two functions for all text boxes ^^^^
End Class
