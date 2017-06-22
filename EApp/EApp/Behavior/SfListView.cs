using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace EApp.Behavior
{
    public class SfListView 
    {


        public static BindableProperty CommandSeletedItemProperty = BindableProperty.CreateAttached(
          propertyName: "CommandSeletedItem",
          returnType: typeof(ICommand),
          declaringType: typeof(SfListView),
          defaultValue: default(ICommand),
          defaultBindingMode: BindingMode.TwoWay,
          propertyChanged : OnSelectedItemChanged
      );

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Syncfusion.ListView.XForms.SfListView view = (Syncfusion.ListView.XForms.SfListView)bindable;
            if (newValue == null|| view==null)
                return;

            view.ItemTapped += (s,e)=>{
                ((ICommand)newValue).Execute(e.ItemData);
            };
        }
 
    }
}
