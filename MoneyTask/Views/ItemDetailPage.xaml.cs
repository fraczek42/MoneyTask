﻿using MoneyTask.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MoneyTask.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}