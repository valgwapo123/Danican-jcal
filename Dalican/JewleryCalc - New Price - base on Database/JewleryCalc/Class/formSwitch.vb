Module formSwitch
    
    Friend Enum FormName As Integer
        Cat = 0

    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal c As Category)
        Select Case gotoForm
            Case FormName.Cat
                frmConsole.LoadCategory(c)
        End Select
    End Sub

End Module