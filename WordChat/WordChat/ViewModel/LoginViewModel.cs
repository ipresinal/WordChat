using System.Security;
using System.Threading.Tasks;
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

            LoginCommand = new RelayParamerizedCmd(async (parameter) => { await Login(parameter);  });

           
        }

        /// <summary>
        /// Attemps to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await Task.Delay(500);
        }

        #endregion

        
    }
}
