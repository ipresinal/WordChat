using System;
using System.Windows;
using System.Windows.Controls;

namespace WordChat
{
    public class PasswordBoxProperties
    {

        public static readonly DependencyProperty MonitorPasswordProperty = 
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = (d as PasswordBox);

            if (passwordBox == null) return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool) e.NewValue)
            {
                SetHadText(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHadText((PasswordBox) sender);
        }

        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }




        public static readonly DependencyProperty HadTextProperty = 
            DependencyProperty.RegisterAttached("HadText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

        private static void SetHadText(PasswordBox element)
        {
            element.SetValue(HadTextProperty, element.SecurePassword.Length > 0);
        }

        public static bool GetHadText(PasswordBox element)
        {
            return  (bool) element.GetValue(HadTextProperty);
        }
    }
}
