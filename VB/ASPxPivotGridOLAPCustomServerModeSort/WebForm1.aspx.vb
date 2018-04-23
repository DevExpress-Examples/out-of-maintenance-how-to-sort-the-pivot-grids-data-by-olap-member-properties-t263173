Imports System
Imports System.Linq
Imports System.Collections
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Web.ASPxPivotGrid

Namespace ASPxPivotGridOLAPCustomServerModeSort
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Creates a new collection of OLAP member properties.
            fieldProduct.AutoPopulatedProperties = New String() { "Color", "List Price" }
            ASPxPivotGrid1.DataBind()
            ' Sets a field's sort mode to Custom to raise the CustomServerModeSort event.
            fieldProduct.SortMode = PivotSortMode.Custom
        End Sub

        Protected Sub ASPxPivotGrid1_CustomServerModeSort(ByVal sender As Object, ByVal e As CustomServerModeSortEventArgs)
            If e.Field.ID = "fieldProduct" Then
                ' Sets the result of comparing the "Product" field's values 
                ' by the "Color" OLAP member property.
                e.Result = Comparer.Default.Compare(e.OLAPMember1.AutoPopulatedProperties("List Price").Value, e.OLAPMember2.AutoPopulatedProperties("List Price").Value)
            End If

        End Sub

        Protected Sub ASPxPivotGrid1_FieldValueDisplayText(ByVal sender As Object, ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Field Is fieldProduct Then
                Dim currentMember As IOLAPMember = e.Field.GetOLAPMembers().First(Function(m) Object.Equals(m.Value, e.Value))
                e.DisplayText += String.Format(" ({0:C2})", currentMember.AutoPopulatedProperties("List Price").Value)
            End If
        End Sub
    End Class
End Namespace