using System;
using System.Linq;
using System.Collections;
using DevExpress.XtraPivotGrid;
using DevExpress.Web.ASPxPivotGrid;

namespace ASPxPivotGridOLAPCustomServerModeSort
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creates a new collection of OLAP member properties.
            fieldProduct.AutoPopulatedProperties = new string[] { "Color", "List Price" };
            ASPxPivotGrid1.DataBind();
            // Sets a field's sort mode to Custom to raise the CustomServerModeSort event.
            fieldProduct.SortMode = PivotSortMode.Custom;
        }

        protected void ASPxPivotGrid1_CustomServerModeSort(object sender, 
            CustomServerModeSortEventArgs e)
        { 
            if (e.Field.ID == "fieldProduct")
            {
                // Sets the result of comparing the "Product" field's values 
                // by the "Color" OLAP member property.
                e.Result = Comparer.Default.Compare(
                    e.OLAPMember1.AutoPopulatedProperties["List Price"].Value,
                    e.OLAPMember2.AutoPopulatedProperties["List Price"].Value
                );
            }
            
        }

        protected void ASPxPivotGrid1_FieldValueDisplayText(object sender, 
            PivotFieldDisplayTextEventArgs e)
        {
            if (e.Field == fieldProduct)
            {
                IOLAPMember currentMember =
                   e.Field.GetOLAPMembers().First(m => Object.Equals(m.Value, e.Value));
                e.DisplayText +=
                   string.Format(" ({0:C2})", currentMember.AutoPopulatedProperties["List Price"].Value);
            }
        }
    }
}