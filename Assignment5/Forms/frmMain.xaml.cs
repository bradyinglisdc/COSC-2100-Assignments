/*
 * Title: frmMain.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: Provides the interaction logic for frmMain.xaml, allowing a user to create, view, update, and delete game reviews.
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Assignment5.DBAL;

#endregion


#region Namespace Definition

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        #region Constructor(s)

        public frmMain()
        {
            DataContext = Game.Games;
            InitializeComponent();
            InitializeSetup();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Loads all games and reviews into memory, then opens login form.
        /// </summary>
        private void InitializeSetup()
        {
            FillModels();
            Login();
            SetGrids();
        }

        /// <summary>
        /// Fills all games and reviews into memory.
        /// </summary>
        private void FillModels()
        {
            Game.FillGames();
            Review.FillReviews();
        }

        /// <summary>
        /// Hides this and opens a login form
        /// </summary>
        private void Login()
        {
            Hide();
            (new frmLogin(this)).Show();
        }

        /// <summary>
        /// Sets item sources for each grid.
        /// </summary>
        private void SetGrids()
        {
            dgrdGames.ItemsSource = Game.Games;
            clmGameTitle.Binding = new Binding("Title");
            clmGameGenre.Binding = new Binding("Genre");
            clmGameReleaseDate.Binding = new Binding("ReleaseDate");


        }

        #endregion

    }
}

#endregion