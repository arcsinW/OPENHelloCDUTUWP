//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using HelloCDUT.Models;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using HelloCDUT.Views;
using HelloCDUT.ViewModels;
using HelloCDUT.Serialization;

namespace HelloCDUT.Facades
{
    /// <summary>
    /// Encapsulates page navigation.
    /// </summary>
    public class NavigationFacade : INavigationFacade
    {
        /// <summary>
        /// The mappings between views and their view models
        /// </summary>
        private static readonly Dictionary<Type, Type> ViewViewModelDictionary = new Dictionary<Type, Type>();

        /// <summary>
        /// The current frame.
        /// </summary>
        private Frame _frame;

        /// <summary>
        /// Determines if back navigation
        /// </summary>
        public bool CanGoBack
        {
            get { return _frame.CanGoBack; }
        }

        /// <summary>
        /// Adds the specified types to the association list.
        /// </summary>
        /// <param name="view">The view type.</param>
        /// <param name="viewModel">The ViewModel type.</param>
        /// <exception cref="System.ArgumentException">The ViewModel has already been added and is only allowed once.</exception>
        public static void AddType(Type view, Type viewModel)
        {
            if (ViewViewModelDictionary.ContainsKey(viewModel))
            {
                throw new ArgumentException("The ViewModel has already been added and is only allowed once.");
            }

            ViewViewModelDictionary.Add(viewModel, view);
        }

        /// <summary>
        /// Makes sure a frame is available that can be used
        /// for navigation.
        /// </summary>
        private void EnsureNavigationFrameIsAvailable()
        {
            var content = Window.Current.Content;

            // The default state is that we expect to have the
            // AppShell as a hosting view for content
            if (content is AppShell)
            {
                var appShell = content as AppShell;
                _frame = appShell.AppFrame;
            }

            // We can also have a simple frame when the user
            // chooses to use the share target contract to share
            // photos from the Windows photos app.
            else if (content is Frame)
            {
                var frameShell = content as Frame;
                _frame = frameShell;
            }
            else
            {
                throw new ArgumentException("Window.Current.Content");
            }
        }


        /// <summary>
        /// Navigates to the specified view model type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="parameter">The parameter. Optional.</param>
        /// <param name="serializeParameter">The serialized parameter. Optional.</param>
        private void Navigate(Type viewModelType, object parameter = null, bool serializeParameter = true)
        {
            var view = ViewViewModelDictionary[viewModelType];

            if (view == null)
            {
                throw new ArgumentException("The specified ViewModel could not be found.");
            }

            // Navigation has to be different if the view is a SettingsFlyout 
            // so this is checked here using reflection
            if (view.GetTypeInfo().IsSubclassOf(typeof(SettingsFlyout)))
            {
                // Create instance and show SettingsFlyout
                var flyout = (SettingsFlyout)Activator.CreateInstance(view);
                flyout.ShowIndependent();
            }
            else
            {
                // This is the navigation logic for views that are not
                // inherited from SettingsFlyout
                EnsureNavigationFrameIsAvailable();

                if (parameter == null)
                {
                    _frame.Navigate(view);
                }
                else
                {
                    if (serializeParameter)
                    {
                        var serialized = SerializationHelper.Serialize(parameter);
                        _frame.Navigate(view, serialized);
                    }
                    else
                    {
                        _frame.Navigate(view, parameter);
                    }
                }
            }
        }

        /// <summary>
        /// Navigates to the about view.
        /// </summary>
        public void NavigateToAboutView()
        {
            Navigate(typeof(AboutViewModel));
        }

        public void GoBack(int steps = 1)
        {
            throw new NotImplementedException();
        }

        public void NavigateToMainView()
        {
            Navigate(typeof(MainViewModel));
        }

        public void NavigateToProfileView()
        {
            Navigate(typeof(WelcomeViewModel));
        }

        public void NavigateToProfileView(User user)
        {
            Navigate(typeof(ProfileViewModel),SerializationHelper.Serialize(user));
        }

        public void NavigateToSignInView()
        {
            Navigate(typeof(SignInViewModel));
        }

        public void NavigateToWelcomeView()
        {
            Navigate(typeof(WelcomeViewModel));
        }

        public void NavigateToCourseView()
        {
            Navigate(typeof(CourseViewModel));
        }

        public void NavigateToLibraryView()
        {
            Navigate(typeof(LibraryViewModel));
        }

        public void NavigateToCampusCardView()
        {
            Navigate(typeof(CampusCardViewModel));
        }
    }
}