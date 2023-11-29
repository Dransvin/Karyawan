
Imports CHR.Common
Public Class ClsTemplate
    Public Function Full() As List(Of iclsCallType)
        Dim l As New List(Of iclsCallType)
        l.Add(New clsCallType_TemplateView)
        l.Add(New clsCallType_TemplateNew)
        l.Add(New clsCallType_TempateEdit)
        l.Add(New clsCallType_TempateDelete)
        l.Add(New clsCallType_TempateRefresh)
        l.Add(New clsCallType_TemplateReport)
        l.Add(New clsCallType_TemplatePrint)
        Return l
    End Function

    Public Function RP() As List(Of iclsCallType)
            Dim l As New List(Of iclsCallType)
            l.Add(New clsCallType_TempateRefresh)
            l.Add(New clsCallType_TemplatePrint)
            Return l
        End Function

        Public Function R() As List(Of iclsCallType)
            Dim l As New List(Of iclsCallType)
            l.Add(New clsCallType_TempateRefresh)
            Return l
        End Function

        Public Function CRUD() As List(Of iclsCallType)
        Dim l As New List(Of iclsCallType)
        l.Add(New clsCallType_TempateRefresh)
        l.Add(New clsCallType_TemplateNew)
        l.Add(New clsCallType_TemplateView)
        l.Add(New clsCallType_TempateEdit)
        l.Add(New clsCallType_TempateDelete)
        Return l
    End Function

        Public Function RF() As List(Of iclsCallType)
            Dim l As New List(Of iclsCallType)
            l.Add(New clsCallType_TempateRefresh)
            l.Add(New clsCallType_TemplateFilter)
            Return l
        End Function

        Public Function CF() As List(Of iclsCallType)
            Dim l As New List(Of iclsCallType)
            l.Add(New clsCallType_TempateRefresh)
            l.Add(New clsCallType_TemplateNew)
            l.Add(New clsCallType_TemplateFilter)
            Return l
        End Function

        Public Function RUDF() As List(Of iclsCallType)
            Dim l As New List(Of iclsCallType)
            l.Add(New clsCallType_TempateRefresh)
            l.Add(New clsCallType_TempateEdit)
            l.Add(New clsCallType_TempateDelete)
            l.Add(New clsCallType_TemplateFilter)
            Return l
        End Function
    End Class

