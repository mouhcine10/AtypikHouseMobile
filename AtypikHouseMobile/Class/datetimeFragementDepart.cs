using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AtypikHouseMobile.Class
{
    class datetimeFragementDepartclass : DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        public static readonly string TAG = "X:" + typeof(DateTimeFragement).Name.ToUpper();

    Action<DateTime> _dateSelectedHandler2 = delegate { };
    public static DateTimeFragement NewInstance(Action<DateTime> onDateSelected)
    {
        DateTimeFragement frag = new DateTimeFragement
        {
            _dateSelectedHandler2 = onDateSelected
        };
        return frag;
    }
    public override Dialog OnCreateDialog(Bundle savedInstanceState)
    {
        DateTime currently = DateTime.Now;
        DatePickerDialog dialog = new DatePickerDialog(Activity,
        this,
        currently.Year,
        currently.Month - 1,
        currently.Day);
        return dialog;
    }
    public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
    {
        DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
        Log.Debug(TAG, selectedDate.ToLongDateString());
        _dateSelectedHandler2(selectedDate);
    }
}
}