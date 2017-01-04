using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Views
{
    /// <summary>
    /// Defines a service for showing dialogs to the user.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Shows a notification that there is an issue with communicating
        /// to the service.
        /// </summary>
        Task ShowGenericServiceErrorNotification();

        /// <summary>
        /// Shows the notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="useResourceLoader">
        /// if set to <c>true</c> the message and title
        /// parameters specify the resource id.
        /// </param>
        Task ShowNotification(string message, string title, bool useResourceLoader = true);

        /// <summary>
        /// Shows a notification that lets the user choose between yes and no.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="useResourceLoader">
        /// if set to <c>true</c> the message and title
        /// parameters specify the resource id.
        /// </param>
        /// <returns>True, if user has chosen yes. Otherwise, false.</returns>
        Task<bool> ShowYesNoNotification(string message, string title, bool useResourceLoader = true);
    }
}
