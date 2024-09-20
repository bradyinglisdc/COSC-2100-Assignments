/*
 * Title: ProductDriver
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: The purpose of this static class is to instantiate 
 * new instance of Product class.
 * 
 * These instances are kept track of in the Product class.
 */
using System.Windows.Forms;

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public class ProductDriver
    {
        /// <summary>
        /// Instantiates some generic products.
        /// </summary>
        public static void InstantiateAllProducts()
        {
            // Clear products list.
            Product.Products.Clear();

            // Add new products
            new Product("Vanilla Cone", 2.90);
            new Product("Chocolate Cone", 3.01);
            new Product("Rocky Road Cone", 3.25);
            new Product("Hot Fudge Sudae", 1.52);
            new Product("Banana Split", 2.05);
            new Product("Salted Caramel Cone", 3.05);
            new Product("Brownie Sundae", 1.81);
            new Product("Kiddie Cone", 0.99);
            new Product("Cotton Candy Cone", 2.75);   
        }

    }
    #endregion
}
#endregion
