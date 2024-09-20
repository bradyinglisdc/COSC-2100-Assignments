/*
 * Title: ProductPanelView
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: The purpose of this class is to define a more customizable alternative to list view.
 * 
 * Essentially just instantiates a list of type Product as Controls and adds them to itself.
 */


#region Namespaces Used
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public class ProductPanelView : Panel
    {
        #region Constructor(s)
        /// <summary>
        /// Constructor sets up self and child controls (each product panel)
        /// </summary>
        public ProductPanelView()
        {
            CreateAndAddControls();
        }
        #endregion

        #region Setup/styling methods
        /// <summary>
        /// Sets up each product panel's child elements, the child panel and the PanelView itself
        /// </summary>
        public void CreateAndAddControls()
        {

        }
        #endregion
    }
    #endregion
}
#endregion
