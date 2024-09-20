/*
 * Title: MainMenuPanel
 * Name: Brady Inglis (100926284)
 * Date: 2024-09-19
 * Purpose: This class contains the definition for a generic class which every game object 
 * will inherit. This helps with type casting.
 * 
 * For an example of the usage of this class, AvailableGames.Games contains a list of different games
 * for organization purposes. In order to store them generically with game names included, they are stored as GenericGamePanels.
 */

#region Namespaces Used
using System.Windows.Forms;
#endregion

#region Namespace Definition
namespace ClassExercise1
{
    #region Class Definition
    public class GenericGamePanel : Panel
    {
        // Simply adds addition of name property to the panel class
        public string GameName
        {
            get;
            set;
        }
    }
    #endregion
}
#endregion