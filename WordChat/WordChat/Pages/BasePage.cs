using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WordChat
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : Page
    {

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

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // if we are animating in, hide to begin with
            if(PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Listen out for the page loading
            Loaded += BasePage_Loaded;
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
            if (PageLoadAnimation != PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                
                case PageAnimation.SlideAndFadeInFromRight:

                    var sb = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(SlideSeconds)),
                        From=new Thickness(WindowWidth, 0, -WindowWidth,0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.9f
                    };

                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                    sb.Children.Add(slideAnimation);

                    sb.Begin(this);

                    Visibility = Visibility.Visible;

                    await Task.Delay((int)(SlideSeconds * 1000));

                    break;

                
            }
        }

        #endregion




    }
}
