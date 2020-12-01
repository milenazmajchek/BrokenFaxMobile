﻿using BrokenFaxMobile.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrokenFaxMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedThreadDetailPage : ContentPage
    {
        public CompletedThreadDetailPage()
        {
            InitializeComponent();
            BindingContext = new CompletedThreadDetailViewModel();
        }
    }
}