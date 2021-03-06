﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using groupProject01;
using groupProject01.Other;
using Xamarin.Forms;

namespace groupProject01
{
	public partial class CreationPage : ContentPage
	{
        GlobalData _gd;     //declares local instances of global data
		public CreationPage (GlobalData gd)     //creation page constructor
		{
            NavigationPage.SetHasNavigationBar(this, false);    //hides the default navigation bar
            _gd = gd;       //sets local instance of global data
			InitializeComponent ();     //initializes ui elements of the page
		}

        async void OnNewApartment(object sender, EventArgs e)   //when new apartment button is clicked
        {
            await(createUser());       //creates a new user
            if(_gd.CurrentUser.UserID == -1)
            {
                return;
            }
            Application.Current.MainPage = new NavigationPage(new groupProject01.CreateNewApartmentPage(_gd));       //direct to home page


        }

        async void OnPrevApartment(object sender, EventArgs e)      //when already have apartment button is clicked
        {
            await (createUser());        //creates a new user
            if (_gd.CurrentUser.UserID == -1)
            {
                return;
            }
            Application.Current.MainPage = new NavigationPage(new groupProject01.PrevApartmentPage(_gd));       //direct to home page


        }

        async void OnBack(object sender, EventArgs e)               //when the back button is pushed
        {
            await Navigation.PopAsync();
        }

        async Task createUser()         //creates a new user
        {
            _gd.CurrentUser = new UserObject();         //sets the current user in global data to a new user object
            _gd.CurrentUser.username = usernameTextField.Text;      //sets the username to the user's input username
            _gd.CurrentUser.email = emailTextField.Text;            //sets the email to the user's input email
            int id = (await(ServerHandeler.createUser(_gd.CurrentUser, passwordTextField.Text)));  //creates user in database and recieves user id back
            _gd.CurrentUser.UserID = id;                            //sets the user id
        }

        
    }
}
