using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Menu_CRUD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowItems();
        }

        private void ShowItems()
        {
            itemsCollection.ItemsSource = App.Db.GetItems();
        }

        private async void AddItemButton(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddItem());

        }
        private async void EditItemButton(object sender, EventArgs e)
        {
            Item itemToEdit = ((Button)sender).BindingContext as Item; // Получите элемент для редактирования
            await Navigation.PushAsync(new EditItem(itemToEdit)); // Передайте элемент на страницу редактирования
        }


        private async void DeleteItemButton(object sender, EventArgs e)
        {
            Item itemToDelete = ((Button)sender).BindingContext as Item; // Получите элемент для удаления
            bool result = await DisplayAlert("Confirmation", "Do you want to delete this item?", "Yes", "No");

            if (result)
            {
                App.Db.DeleteItem(itemToDelete); // Удалите элемент из базы данных
                ShowItems(); // Обновите список элементов
            }
        }


    }
}
