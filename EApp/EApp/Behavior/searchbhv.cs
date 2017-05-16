using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.Behavior
{
    public class searchbhv
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
            propertyName: "Command",
            returnType: typeof(ICommand),
            declaringType: typeof(searchbhv),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnCommandChanged
            );

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var searchBar = bindable as SearchBar;
            if (searchBar != null && newValue != null)
            {
                searchBar.TextChanged += (sender, e) =>
                {
                    var command = newValue as ICommand;
                    if (command.CanExecute(e.NewTextValue))
                    {
                        command.Execute(e.NewTextValue);
                    }
                };

            };


        }


    }
}
