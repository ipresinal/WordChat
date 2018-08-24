using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WordChat.ViewModel
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        #endregion


        #region Public Properties

        public string Test { get; set; } = "MyString";

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            mWindow = window;
        }

        #endregion
    }
}
