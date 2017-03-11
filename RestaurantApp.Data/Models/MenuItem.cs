using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Models
{
  public  class MenuItem
    {
        public Type ViewType { get; set; }
        public string Title { get; set; }
        public object Params { get; set; }

        public MenuItem(Type type, string title)
        {
            Title = title;
            ViewType = type;
        }
        public MenuItem(Type type, string title,object parameter)
        {
            Title = title;
            ViewType = type;
            Params = parameter;
        }
    }
}
