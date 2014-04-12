using UnityEngine;
using System.Collections;
using System;

public class CQDate : System.Object
{
	protected DateTime date;

	public int Year { get { return date.Year; } }
	public int Month { get { return date.Month; } }
	public int Day { get { return date.Day; } }

	public CQDate(int day, int month, int year)
	{
		date = new DateTime(year, month, day);
	}

	public CQDate(DateTime date)
	{
		this.date = new DateTime(date.Year, date.Month, date.Day);
	}

	public CQDate(CQDate date)
	{
		this.date = new DateTime(date.Year, date.Month, date.Day);
	}

	public static CQDate TodaysDate()
	{
		return new CQDate(DateTime.Today);
	}

	public CQDate Clone()
	{
		return new CQDate(this);
	}
	
	public CQDate(string date)
	{
		// Assumes DD-MM-YYYY

		int day = 0;
		bool success = int.TryParse(date.Substring(0, 2), out day);
		if (!success)
		{
			Debug.LogError("Could not parse date correctly: " + date);
			return;
		}

		int month = 0;
		success = int.TryParse(date.Substring(3, 2), out month);
		if (!success)
		{
			Debug.LogError("Could not parse date correctly");
			return;
		}

		int year = 0;
		success = int.TryParse(date.Substring(6, 4), out year);
		if (!success)
		{
			Debug.LogError("Could not parse date correctly");
			return;
		}
		
		this.date = new DateTime(year, month, day);
	}

	public static TimeSpan operator -(CQDate date1, CQDate date2)
	{
		return date1.date - date2.date;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null) return false;
		CQDate date = obj as CQDate;
		if (date == null) return false;

		return Year == date.Year && Month == date.Month && Day == date.Day;
	}

	public static bool operator ==(CQDate date1, CQDate date2)
	{
		if (System.Object.ReferenceEquals(date1, date2))
		{
			return true;
		}

		if (((object)date1 == null) || ((object)date2 == null))
		{
			return false;
		}

		return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
	}

	public static bool operator !=(CQDate date1, CQDate date2)
	{
		return !(date1 == date2);
	}

	public static CQDate operator ++(CQDate date1)
	{
		date1.date = date1.date.AddDays(1);
		return date1;
	}

	public static bool operator <(CQDate date1, CQDate date2)
	{
		if(date1.Year < date2.Year) return true;
		if(date1.Month < date2.Month) return true;
		if(date1.Day < date2.Day) return true;

		return false;
	}

	public static bool operator >(CQDate date1, CQDate date2)
	{
		if (date1.Year > date2.Year) return true;
		if (date1.Month > date2.Month) return true;
		if (date1.Day > date2.Day) return true;

		return false;
	}

	public override string ToString()
	{
		return string.Format("{0}-{1}-{2}", date.Day.ToString("D" + 2), date.Month.ToString("D" + 2), date.Year.ToString("D" + 4));
	}
}
