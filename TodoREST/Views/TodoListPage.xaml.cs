using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoREST.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = await App.TodoManager.GetTasksAsync();
		}

		async void OnAddItemClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage(true)
			{
				BindingContext = new TodoItem
				{
					ID = Guid.NewGuid().ToString()
				}
			});
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
	}
}