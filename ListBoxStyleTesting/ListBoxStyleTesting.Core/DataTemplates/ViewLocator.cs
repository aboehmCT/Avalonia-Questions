using Avalonia.Controls.Templates;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;
using ListBoxStyleTesting.ViewModels;

using System;

namespace ListBoxStyleTesting
{
    public class ViewLocator : IDataTemplate
    {
        public Guid ID = Guid.NewGuid();
        public Control Build(object? data)
        {
            if (data is null)
            {
                return new TextBlock { Text = "data was null" };
            }

            var assembly = data.GetType().Assembly;
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = assembly.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
