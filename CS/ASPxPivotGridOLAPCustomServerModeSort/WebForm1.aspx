<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPxPivotGridOLAPCustomServerModeSort.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" 
            OLAPConnectionString="provider=MSOLAP;
            data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll; 
            initial catalog=Adventure Works DW Standard Edition;cube name=Adventure Works;" 
            Theme="Metropolis" OLAPDataProvider="Adomd" 
            oncustomservermodesort="ASPxPivotGrid1_CustomServerModeSort" 
            onfieldvaluedisplaytext="ASPxPivotGrid1_FieldValueDisplayText">
             <Fields>
                <dx:PivotGridField ID="fieldSalesAmount" Area="DataArea" AreaIndex="0" Caption="Sales Amount" DisplayFolder="Sales Summary" FieldName="[Measures].[Sales Amount]" SortByAttribute="">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldProduct" Area="RowArea" AreaIndex="0" Caption="Product" FieldName="[Product].[Product].[Product]" SortByAttribute="" SortMode="Custom">
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldCategory" AreaIndex="1" Caption="Category" 
                     FieldName="[Product].[Category].[Category]" SortByAttribute="" 
                     Area="ColumnArea" Visible="False">
                </dx:PivotGridField>
                 <dx:PivotGridField ID="fieldFiscalYear" Area="ColumnArea" AreaIndex="0" 
                     Caption="Year" DisplayFolder="Fiscal" 
                     FieldName="[Date].[Fiscal Year].[Fiscal Year]" 
                     ValueFormat-FormatString="d" ValueFormat-FormatType="Custom">
                 </dx:PivotGridField>
            </Fields>
        </dx:ASPxPivotGrid>
    </div>
    </form>
</body>
</html>
