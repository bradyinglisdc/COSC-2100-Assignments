/*
 * Title: ProductDriver
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: The purpose of this static class is to instantiate 
 * new instance of Product class.
 * 
 * These instances are kept track of in the Product class.
 */

#region Namespace Definition
namespace ClassExercise1.GameControlObjects.Ice_Cream
{
    #region Class Definition
    public class ProductDriver
    {
        public static void InstantiateAllProducts()
        {
            new Product("Vanilla Cone", 2.90);
            new Product("Chocolate Cone", 3.0);
            new Product("Rocky Road Cone", 3.25);
            new Product("Hot Fudge Sudae", 1.5);
            new Product("Banana Split", 2.0);
        }

    }
    #endregion
}
#endregion
