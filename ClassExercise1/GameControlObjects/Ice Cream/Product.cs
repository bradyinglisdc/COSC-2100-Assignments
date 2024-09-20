/*
 * Title: Product
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-20
 * Purpose: The purpose of this class is to encapsulate a generic Product item with
 * a name and a price.
 * 
 * Static list of all instantiated products is kept
 */


#region Namespaces Used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public class Product
    {
        #region Static variables
        public static List<Product> Products = new List<Product>();
        #endregion

        #region Properties
        public string Name
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Automatically keeps track of each new instance created.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            Products.Add(this);
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Searches through static list of products and returns if a match is found,
        /// otherwise returns null.
        /// </summary>
        /// <param name="name">The name of the product to find.</param>
        /// <returns></returns>
        public static Product FindByName(string name)
        {
            foreach (Product product in Products)
            {
                if (product.Name == name) { return product; }
            }

            return null;
        }
        #endregion
    }
    #endregion
}
#endregion
