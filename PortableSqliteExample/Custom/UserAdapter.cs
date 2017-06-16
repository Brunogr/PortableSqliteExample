using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Core.Data.Entity;

namespace PortableSqliteExample.Custom
{
    public class UserAdapter : BaseAdapter
    {
        public List<User> _Users { get; set; }
        public Activity _Activity { get; set; }
        public override int Count {
            get { return _Users.Count; }
        }

        public UserAdapter(Activity aActivity, List<User> aUsers)
        {
            _Activity = aActivity;
            _Users = aUsers;
        }

      
        public override Java.Lang.Object GetItem(int position)
        {
            return null;// _Users[position];
        }

        public override long GetItemId(int position)
        {
            return _Users[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _Activity.LayoutInflater.Inflate(
                            Resource.Layout.UserListItem, parent, false);

            var userEmail = view.FindViewById<TextView>(Resource.Id.textUserEmail);
            var userName = view.FindViewById<TextView>(Resource.Id.textUserName);

            userEmail.Text = _Users[position].Email;
            userName.Text = _Users[position].Name;

            return view;
        }
    }
}