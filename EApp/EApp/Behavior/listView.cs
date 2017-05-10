using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EApp.Behavior
{
    public static class listView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
            propertyName : "Command",
            returnType : typeof(ICommand),
            declaringType:typeof(listView),
            defaultValue:null,
            defaultBindingMode:BindingMode.TwoWay,
            propertyChanged: OnCommandChanged
            );

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var list = bindable as ListView;
            if (list == null)
                return;
            //list.ItemTapped += List_ItemTapped;
            list.ItemTapped += (sender, e) =>
            {
                // do something here
                var command = newValue as ICommand;
                if (command == null)
                    return;
                if (command.CanExecute(e.Item))
                {
                    command.Execute(e.Item);
                }
            };

        }

        //private static void List_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}
    }
}
