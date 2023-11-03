﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private async void AddItemButton(object sender, EventArgs e)
        {
            string title = titleField.Text.Trim();
            string desc = descField.Text.Trim();
            string image = imageField.Text.Trim();
            int price = Convert.ToInt32(priceField.Text.Trim());

            if (title.Length < 5)
            {
                await DisplayAlert("Error", "Title min 5", "Ok");
                return;
            }
            else if (desc.Length < 10)
            {
                await DisplayAlert("Error", "Desc min 10", "Ok");
                return;
            }
            else if (image.Length < 15)
            {
                await DisplayAlert("Error", "Image min 15", "Ok");
                return;
            }
            else if (price < 20)
            {
                await DisplayAlert("Error", "Price min 20", "Ok");
                return;
            }

            Item item = new Item
            {
                Title = title,
                Desc = desc,
                Image = image,
                Price = price
            };
            App.Db.SaveItem(item);
  

            titleField.Text = "";
            descField.Text = "";
            imageField.Text = "";
            priceField.Text = "";


        }
    }
}