using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace WordChat
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page
    where VM:BaseViewModel, new()
    {
        #region Private Member

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        private VM _mViewModel;

       



        #endregion

        #region Properties

        /// <summary>
        /// The animation the play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation the play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation take to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return _mViewModel; }
            set
            {
                // if nothing has changed, return
                if (_mViewModel == value) return;

                // Update the value
                _mViewModel = value;

                // Set the data context for this page
                DataContext = _mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // if we are animating in, hide to begin with
            if(PageLoadAnimation == PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Listen out for the page loading
            Loaded += BasePage_Loaded;

            // Create default view model
            ViewModel = new VM();
        }

        #endregion


        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
           await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                
                case PageAnimation.SlideAndFadeInFromRight:

                    // Start the animation
                    await this.SlideAndFadeInFromRight(SlideSeconds);

                    break;

                
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (PageUnLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnLoadAnimation)
            {

                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeft(SlideSeconds);

                    break;


            }
        }

        #endregion

 



    }
}
