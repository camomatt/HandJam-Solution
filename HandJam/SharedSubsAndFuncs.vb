Public Class SharedSubsAndFuncs
    ''' <summary>
    ''' Returns an object array containing file names and optionally their associated subdirectories. Default value for subdirectory is false.
    ''' </summary>
    ''' <param name="dir">Directory.</param>
    ''' <param name="s">Boolean for subdirectories.</param>
    ''' <remarks></remarks>
    Public Function GetListOfFilesFromDirectory(ByVal dir As String, Optional ByVal s As Boolean = False) As Object()
        Dim list As Object() = {}
        Dim index As Integer = 0
        Dim subStr As String

        'If the directory doesn't exist, display error and return an empty list
        If FileIO.FileSystem.DirectoryExists(dir) = False Then
            MessageBox.Show("The following directory does not exist and files cannot be retrieved." & vbNewLine & vbNewLine & dir, "Directory Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return list
        End If

        If s Then
            For Each i In My.Computer.FileSystem.GetFiles(dir, FileIO.SearchOption.SearchAllSubDirectories)
                ReDim Preserve list(index)
                subStr = i.Substring(dir.Length + 1, i.Length - dir.Length - 1)
                list(index) = subStr
                index += 1
            Next
        Else
            For Each i In My.Computer.FileSystem.GetFiles(dir, FileIO.SearchOption.SearchTopLevelOnly)
                ReDim Preserve list(index)
                subStr = i.Substring(dir.Length + 1, i.Length - dir.Length - 1)
                list(index) = subStr
                index += 1
            Next
        End If

        Return list
    End Function

    ''' <summary>
    ''' Returns an object array containing label names from the setget.
    ''' </summary>
    ''' <param name="setget">The setget containing all control properties.</param>
    ''' <remarks></remarks>
    Public Function GetListOfStrings(setget As SettersAndGetters) As Object()
        Dim labelColl As Object() = {}
        Dim colCount As Integer = setget.RPControls.GetUpperBound(1)

        For r As Integer = 0 To colCount - 1
            ReDim Preserve labelColl(r)
            labelColl(r) = setget.RPControls(0, r)
        Next

        Return labelColl
    End Function

    ''' <summary>
    ''' Returns an object array containing a list of Strings belonging to the specified array at the specified index.
    ''' </summary>
    ''' <param name="array">The setget containing all control properties.</param>
    ''' <param name="i">The setget containing all control properties.</param>
    ''' <remarks></remarks>
    Public Function GetListOfStrings(array As Object(,), i As Integer) As Object()
        Dim labelColl As Object() = {}
        Dim colCount As Integer = array.GetUpperBound(1)

        For r As Integer = 0 To colCount - 1
            ReDim Preserve labelColl(r)
            labelColl(r) = array(i, r)
        Next

        Return labelColl
    End Function

    ''' <summary>
    ''' Returns a string array containing attributes assigned to the specified type.
    ''' </summary>
    ''' <param name="t">A string representing a type. Must be "text", "image", or "shape".</param>
    Public Function GetListOfAttributesByType(t As String) As String()
        Select Case t.ToLower
            Case "text"
                Return {"label", "text", "x", "y", "detect_size", "width", "height", "multiline", "lines", "font", "main_color", "main_alpha", "alpha", "shadow", "shadow_color", "shadow_alpha", "distance", "rotation", "default"}
            Case "image"
                Return {"label", "image", "x", "y", "detect_size", "width", "height", "directory", "subdirectories", "default"}
            Case "shape"
                Return {"label", "shape", "x", "y", "detect_size", "width", "height", "selected_shape", "outline_color", "outline_alpha", "thickness", "fill_color", "fill_alpha"}
            Case Else
                MessageBox.Show("Invalid type of control found. Aborting function.", "Invalid Control", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
        End Select
    End Function
End Class
