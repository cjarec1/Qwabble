﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace groupProject01
{
    public class CalendarData
    {

        DateTime todayWithTime;
        public ObservableCollection<CalendarOptionObject> options { get; set; } //declares options ObservableCollection that will notify when options are added, removed, and refreshed
        public List<EventObject> events { get; set; }   //declares calItems ObservableCollection that will notify when calendar items are added, removed, and refreshed

        public CalendarData()                                                 //constructor for the Calendar Data page
        {
            refreshAll();                                                     //refreshes all data on the page
            todayWithTime = DateTime.Today;                                   //sets date
        }

        public void refreshAll()                                             //refreshes all data on the page
        {
            options = new ObservableCollection<CalendarOptionObject>();         //instantiates calendar options ObservableCollection that will notify when calendar options are added, removed, and refreshed
            
            options.Add(new CalendarOptionObject { Name = "View Calendar", ID = options.Count });              //adds the View Calendar option to the page
        }

        //make different objects for each type, be able to access all
        async public void getEventsInCalendar(GlobalData gd, int CalendarID)                     //gets all events for a specific calendar
        {
            events = await (ServerHandeler.getCalendar(gd));

            /*events = new ObservableCollection<EventObject>();        //instantiates events ObservableCollection that will notify when events are added, removed, and refreshed

            //HARD-CODED, WILL CHANGE

            events.Add(new EventObject { name = "AppearOnAll", eventID = events.Count, userid = 1, startDate= todayWithTime, endDate= todayWithTime, AdditionalInfo = "HELLO I AM ADDITIONAL INFO WHO ARE YOU" });     //adds the first event to the page
            if(CalendarID == 0)                                 //adds the following events to the View Calendar page
            {
                events.Add(new EventObject { name = "Party", eventID = events.Count, userid = 0, startDate = todayWithTime, endDate = todayWithTime, AdditionalInfo = "haha. connor throwing a party." });     //adds the  event to the View Calendar page
            }
            if(CalendarID == 1)                                                            //adds the following options to the New Event page
            {
                events.Add(new EventObject { name = "Schedule New Guests", eventID = events.Count, userid = 1, startDate = todayWithTime, endDate = todayWithTime, AdditionalInfo = "" });        //adds the Schedule New Guests to the New Event page
                events.Add(new EventObject { name = "Schedule Chore", eventID = events.Count, userid = 1, startDate = todayWithTime, endDate = todayWithTime, AdditionalInfo = "" });             //adds the Schedule Chore to the New Event page
                events.Add(new EventObject { name = "Reserve Laundry Machines", eventID = events.Count, userid = 0, startDate = todayWithTime, endDate = todayWithTime, AdditionalInfo = "" });   //adds the Reserve Laundry Machines to the New Event page
                events.Add(new EventObject { name = "Reserve Quiet Time", eventID = events.Count, userid = 1, startDate = todayWithTime, endDate = todayWithTime, AdditionalInfo = "" });         //adds the Reserve Quiet Time to the New Event page
            }*/
        }
    }
    public class EventObject
    {

        //createEvent(username, startDate, endDate, name, userID, apartmentID)
        public int id { get; set;}
        public int eventID { get; set; }
        public int userid { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int apartmentid { get; set; }
        //TODO should we implement this?

        public string AdditionalInfo { get; set; }
    }
    public class CalendarOptionObject
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
