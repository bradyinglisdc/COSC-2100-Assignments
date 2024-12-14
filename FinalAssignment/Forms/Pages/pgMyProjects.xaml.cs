/*
 * Title: pgMyProjects.xaml.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-13
 * Purpose: Displays logged in user's projects, allows them to navigate them.
 *  
 * AI Use and Documentation: No AI used for this class.
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalAssignment.Models;

#endregion

#region Namespace Definition

namespace FinalAssignment
{
    /// <summary>
    /// Interaction logic for pgMyProjects.xaml
    /// </summary>
    public partial class pgMyProjects : Page
    {
        #region Events

        public event ProjectContainerStyling.EditRequestedHandler? EditRequested;

        #endregion

        #region Instance Properties

        /// <summary>
        /// List of all this user's projects.
        /// </summary>
        private List<Project> Projects = new List<Project>();

        /// <summary>
        /// Keeps track of the currently selected project.
        /// </summary>
        private Project? SelectedProject;

        /// <summary>
        /// Keeps track of the currently selected project container.
        /// </summary>
        private Border? SelectedProjectContainer;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor - just parses xaml and displays all user's projects.
        /// </summary>
        public pgMyProjects()
        {
            InitializeComponent();
            DisplayProjects();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Styles to indicate mouse hover.
        /// </summary>
        /// <param name="sender">Project container.</param>
        /// <param name="e">Event Args.</param>
        private void ProjectContainer_MouseEnter(object sender, MouseEventArgs e)
        {
            Border projectContainer = (Border)sender;
            
            // Do nothing if this container is selected
            if (projectContainer == SelectedProjectContainer) { return; }

            projectContainer.Background = ProjectContainerStyling.HOVER_BORDER_CONTAINER_BACKGROUND;
        }

        /// <summary>
        /// Styles to indicate mouse leave.
        /// </summary>
        /// <param name="sender">Project container.</param>
        /// <param name="e">Event Args.</param>
        private void ProjectContainer_MouseLeave(object sender, MouseEventArgs e)
        {
            Border projectContainer = (Border)sender;

            // Do nothing if this container is selected
            if (projectContainer == SelectedProjectContainer) { return; }

            projectContainer.Background = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_BACKGROUND;
        }

        /// <summary>
        /// Selects the project container.
        /// </summary>
        /// <param name="sender">Project container.</param>
        /// <param name="e">Event Args.</param>
        private void ProjectContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectProject((Border)sender);
        }

        /// <summary>
        /// Invokes EditRequested event with the selected project.
        /// </summary>
        /// <param name="sender">btnEdit</param>
        /// <param name="e">Event Args.</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedProject == null) { return; }
            EditRequested?.Invoke(SelectedProject);
        }

        /// <summary>
        /// Invokes EditRequested event with a new project.
        /// </summary>
        /// <param name="sender">btnEdit</param>
        /// <param name="e">Event Args.</param>
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            EditRequested?.Invoke(new Project());
        }

        #endregion

        #region Setup

        /// <summary>
        /// Pulls all user projects and displays a clickable project foreach. 
        /// </summary>
        private void DisplayProjects()
        {
            // Show an error if user was logged out
            if (User.CurrentUser == null)
            {
                MessageBox.Show("Error! User is logged out.");
                return;
            }

            // Create a clickable styled border for each project
            foreach (Project project in Project.GetProjectsByUserID(User.CurrentUser.UserID))
            {
                CreateProjectContainer(project);
            }
        }

        /// <summary>
        /// Creates a styled border for the specified file.
        /// </summary>
        /// <param name="project">The project to display.</param>
        private void CreateProjectContainer(Project project)
        {
            Border projectContainer = new Border()
            {
                Background = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_BACKGROUND,
                Width = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_WIDTH,
                Height = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_HEIGHT,
                Margin = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_MARGIN,
                CornerRadius = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_CORNER_RADIUS,
                Name = $"n{project.ProjectID.ToString()}"
            };
            projectContainer.Child = new TextBlock()
            {
                Text = project.Name,
                Foreground = Brushes.White,
                FontSize = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_FONT_SIZE,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            projectContainer.MouseEnter += ProjectContainer_MouseEnter;
            projectContainer.MouseLeave += ProjectContainer_MouseLeave;
            projectContainer.MouseLeftButtonDown += ProjectContainer_MouseLeftButtonDown;

            Projects.Add(project);
            pnlMyProjects.Children.Add(projectContainer);
        }

        #endregion

        #region Logic

        /// <summary>
        /// Selects the described project and deselcts the current.
        /// </summary>
        /// <param name="project">Project container to select.</param>
        private void SelectProject(Border projectContainer)
        {
            // Deselect current project and select current
            if (SelectedProjectContainer != null) { SelectedProjectContainer.Background = ProjectContainerStyling.DEFAULT_BORDER_CONTAINER_BACKGROUND; }
            
            SelectedProjectContainer = projectContainer;
            projectContainer.Background = ProjectContainerStyling.SELECT_BORDER_CONTAINER_BACKGROUND;

            // Set the currently selected project to the new one
            foreach (Project project in Projects)
            {
                if (project.ProjectID.ToString() == projectContainer.Name.Split('n')[1])
                {
                    SelectedProject = project;
                }
            }

        }

        #endregion

    }
}

#endregion