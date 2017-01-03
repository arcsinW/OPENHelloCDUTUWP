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

using HelloCDUT.Core.Model;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace HelloCDUT.Facades
{
    /// <summary>
    /// Encapsulates page navigation.
    /// </summary>
    public interface INavigationFacade
    {
        /// <summary>
        /// Goes back to the previews view(s).
        /// </summary>
        /// <param name="steps">Number of views to go back.</param>
        void GoBack(int steps = 1);

        /// <summary>
        /// Navigates to the about view.
        /// </summary>
        void NavigateToAboutView();


        void NavigateToMainView(); 


        /// <summary>
        /// Navigates to the signed-in user's profile view.
        /// </summary>
        void NavigateToProfileView();

        /// <summary>
        /// Navigates to the given user's profile view.
        /// </summary>
        /// <param name="user">The user to show the profile view for.</param>
        void NavigateToProfileView(User user);


        /// <summary>
        /// Navigates to the sign-in view.
        /// </summary>
        void NavigateToSignInView();
         

        /// <summary>
        /// Navigates to the Welcome view.
        /// </summary>
        void NavigateToWelcomeView();  
    }
}