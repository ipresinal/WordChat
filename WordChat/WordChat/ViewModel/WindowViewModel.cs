using System.Windows;
using System.Windows.Input;


namespace WordChat
{   
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// The Window this view Model Controls
        /// </summary>
        private Window _mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int _mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _mWindowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition _mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        /// <summary>
        ///  The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        ///  The smallest Height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        public bool Borderless
        {
            get
            {
                return (_mWindow.WindowState == WindowState.Maximized || _mDockPosition != WindowDockPosition.Undocked);
            }
        }
        

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder
        {
            get { return Borderless ? 0 : 6; }
        } 

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness
        {
            get { return new Thickness(ResizeBorder + OuterMarginSize); }
        }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {                              
                return Borderless ? 0 : _mOuterMarginSize;
            }
            set { _mOuterMarginSize = value; }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get { return new Thickness(OuterMarginSize); }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get { return _mWindow.WindowState == WindowState.Maximized ? 0 : _mWindowRadius; }
            set { _mWindowRadius = value; }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius
        {
            get { return new CornerRadius(WindowRadius); }
        }

        /// <summary>
        /// The Height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength
        {
            get { return new GridLength(TitleHeight + ResizeBorder); }
        }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }

        #endregion

        #region Commands

        public ICommand MinimizeCmd { get; set; }
        public ICommand MaximizeCmd { get; set; }
        public ICommand CloseCmd { get; set; }
        public ICommand MenuCmd { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            _mWindow = window;

            //Listen out for the window resizing
            _mWindow.StateChanged += (Sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged("ResizeBorderThickness");
                OnPropertyChanged("OuterMarginSize");
                OnPropertyChanged("OuterMarginSizeThickness");
                OnPropertyChanged("WindowRadius");
                OnPropertyChanged("WindowCornerRadius");
            };

            MinimizeCmd = new RelayCommand(action => { _mWindow.WindowState = WindowState.Minimized; });
            MaximizeCmd = new RelayCommand(action => { _mWindow.WindowState ^= WindowState.Maximized; });
            CloseCmd = new RelayCommand(action => { _mWindow.Close(); });
            MenuCmd = new RelayCommand(action => { SystemCommands.ShowSystemMenu(_mWindow, GetMousePosition()); });

            // Fix window resize issue
            var resizer = new WindowResizer(_mWindow);
        }

        #endregion

        #region Private Helpers


        private Point GetMousePosition()
        {
            //var position = Mouse.GetPosition(_mWindow);
            //return new Point(position.X + _mWindow.Left, position.Y + _mWindow.Top);

            return _mWindow.PointToScreen(Mouse.GetPosition(_mWindow));
        }

        #endregion
    }
}
