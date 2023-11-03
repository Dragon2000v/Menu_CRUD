using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItem : ContentPage
    {
        private Item itemToEdit;

        public EditItem(Item item)
        {
            InitializeComponent();
            itemToEdit = item;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (itemToEdit != null)
            {
                titleField.Text = itemToEdit.Title;
                descField.Text = itemToEdit.Desc;
                imageField.Text = itemToEdit.Image;
                priceField.Text = itemToEdit.Price.ToString();
            }
        }

        private void SaveChangesButton(object sender, EventArgs e)
        {
            itemToEdit.Title = titleField.Text;
            itemToEdit.Desc = descField.Text;
            itemToEdit.Image = imageField.Text;
            itemToEdit.Price = Convert.ToInt32(priceField.Text);

            // Обновите элемент в базе данных
            App.Db.UpdateItem(itemToEdit);

            Navigation.PopAsync(); // Вернитесь на главную страницу после сохранения изменений
        }



    }
}