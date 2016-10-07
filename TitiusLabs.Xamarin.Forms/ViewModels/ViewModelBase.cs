using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace TitiusLabs.Xamarin.Forms.ViewModels
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		Dictionary<string, object> properties = new Dictionary<string, object>();
		Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

		const string EXECUTECOMMAND_SUFFIX = "_ExecuteCommand";
		const string CANEXECUTECOMMAND_SUFFIX = "_CanExecuteCommand";

		public ViewModelBase()
		{
			this.commands =
				this.GetType().GetTypeInfo().DeclaredMethods
				.Where(dm => dm.Name.EndsWith(EXECUTECOMMAND_SUFFIX, StringComparison.Ordinal))
				.ToDictionary(k => GetCommandName(k), v => GetCommand(v));
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
		{
			if (!properties.ContainsKey(propertyName))
			{
				properties.Add(propertyName, default(T));
			}

			var oldValue = GetValue<T>(propertyName);
			if (!EqualityComparer<T>.Default.Equals(oldValue, value))
			{
				properties[propertyName] = value;
				OnPropertyChanged(propertyName);
			}
		}

		protected T GetValue<T>([CallerMemberName] string propertyName = null)
		{
			if (!properties.ContainsKey(propertyName))
			{
				return default(T);
			}
			else {
				return (T)properties[propertyName];
			}
		}

		private string GetCommandName(MethodInfo mi)
		{
			return mi.Name.Replace(EXECUTECOMMAND_SUFFIX, "");
		}

		private ICommand GetCommand(MethodInfo mi)
		{
			var canExecute = this.GetType().GetTypeInfo().GetDeclaredMethod(GetCommandName(mi) + CANEXECUTECOMMAND_SUFFIX);
			var executeAction = (Action<object>)mi.CreateDelegate(typeof(Action<object>), this);
			var canExecuteAction = canExecute != null ? (Func<object, bool>)canExecute.CreateDelegate(typeof(Func<object, bool>), this) : state => true;
			return new Command(executeAction, canExecuteAction);
		}

		public ICommand this[string name]
		{
			get
			{
				return commands[name];
			}
		}
	}
}
