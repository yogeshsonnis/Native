using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Ividence.Programmatic.Renderer.Core.Models
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> prop)
        {
            if (this.PropertyChanged == null) return;

            var name = ((prop?.Body as MemberExpression)?.Member as PropertyInfo)?.Name;
            if (!String.IsNullOrEmpty(name))
                this.RaisePropertyChanged(name);
        }
    }
}
