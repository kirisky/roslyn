﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Namespace Microsoft.CodeAnalysis.Editor.VisualBasic.UnitTests.EndConstructGeneration
    <[UseExportProvider]>
    <Trait(Traits.Feature, Traits.Features.EndConstructGeneration)>
    Public Class TryBlockTests
        <WpfFact>
        Public Async Function ApplyAfterTryStatement() As Task
            Await VerifyStatementEndConstructAppliedAsync(
                before:="Class c1
Sub goo()
Try
End Sub
End Class",
                beforeCaret:={2, -1},
                after:="Class c1
Sub goo()
Try

Catch ex As Exception

End Try
End Sub
End Class",
                afterCaret:={3, -1})
        End Function

        <WpfFact>
        Public Async Function DoNotApplyForMatchedTryWithCatch() As Task
            Await VerifyStatementEndConstructNotAppliedAsync(
                text:="Class c1
Sub goo()
Try
Catch ex As Exception
End Try
End Sub
End Class",
                caret:={2, -1})
        End Function

        <WpfFact>
        Public Async Function DoNotApplyForMatchedTryWithoutCatch() As Task
            Await VerifyStatementEndConstructNotAppliedAsync(
                text:="Class c1
Sub goo()
Try
End Try
End Sub
End Class",
                caret:={2, -1})
        End Function

        <WpfFact>
        Public Async Function VerifyNestedTryBlock() As Task
            Await VerifyStatementEndConstructAppliedAsync(
                before:="Class C
    Sub S
        Try
        Catch ex As Exception
        Finally
            Try
        End Try
    End Sub
End Class",
                beforeCaret:={5, -1},
                 after:="Class C
    Sub S
        Try
        Catch ex As Exception
        Finally
            Try

            Catch ex As Exception

            End Try
        End Try
    End Sub
End Class",
                afterCaret:={6, -1})
        End Function

        <WpfFact>
        Public Async Function VerifyNestedTryBlockWithCode() As Task
            Await VerifyStatementEndConstructAppliedAsync(
                before:="Class C
    Sub S
        Try
        Dim x = 1
        Dim y = 2
    End Sub
End Class",
                beforeCaret:={2, -1},
                 after:="Class C
    Sub S
        Try

        Catch ex As Exception

        End Try
        Dim x = 1
        Dim y = 2
    End Sub
End Class",
                afterCaret:={3, -1})
        End Function

        <WpfFact>
        Public Async Function VerifyMissingCatchInTryBlock() As Task
            Await VerifyStatementEndConstructNotAppliedAsync(
                text:="Class C
    Sub S
        dim x = function(x)
                    try
                    End Try
                    x += 1
                End function
    End Sub
End Class",
                caret:={3, -1})
        End Function

        <WpfFact>
        Public Async Function VerifyInvalidSyntax() As Task
            Await VerifyStatementEndConstructNotAppliedAsync(
                text:="Class EC
    Sub S
        Dim x = try
    End Sub
End Class",
                caret:={2, -1})
        End Function

        <WpfFact>
        Public Async Function VerifyInvalidLocation() As Task
            Await VerifyStatementEndConstructNotAppliedAsync(
                text:="Class EC
    Sub Try
End Class",
                caret:={1, -1})
        End Function
    End Class
End Namespace
