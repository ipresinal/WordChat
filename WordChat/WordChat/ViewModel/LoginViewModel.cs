using System.Security;
using System.Windows;
using System.Windows.Input;


namespace WordChat
{   
    /// <summary>
    /// The View Model for the login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member

        

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public SecureString Password { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {
                  
            MenuCmd = new RelayCommand(action => { SystemCommands.ShowSystemMenu(_mWindow, GetMousePosition()); });

           
        }

        #endregion

        
    }
}
