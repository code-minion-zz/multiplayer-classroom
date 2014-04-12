using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class RecordScreen : MonoBehaviour 
{
    public WeeklyRecord[] weeklyRocords;

	private List<CQDate> dates = new List<CQDate>();

	public void Start()
	{
		// NOTE: Do not use this test data when live.
		InitialiseTestData();

		// Disable all stars
		foreach (WeeklyRecord week in weeklyRocords)
		{
			week.EnableStars(false);
		}

		// Enable all stars that have been obtained.
		List<CQDate> datesAttended = CharacterData.Attendance;

		CQDate date = CharacterData.termStartDate.Clone();
		CQDate todaysDate = CQDate.TodaysDate().Clone();

		for (int i = 0; date < todaysDate; ++date, ++i)
		{
			CQDate attendedDay = datesAttended.Find(x => x == date);

			if (attendedDay != null)
			{
				int week = Mathf.FloorToInt((float)i / 7.0f);
				int day = i - (week * 7);
				//Debug.Log("Week: " + week + ", Day: " + day + "(" + i + ")");
				weeklyRocords[week].starSlots[day].EnableStar(true);
			}
		}

		// TODO: Hide weeks that aren't in this term
		for (int i = CharacterData.weeksInTerm - 1; i < 11; ++i)
		{
			weeklyRocords[i].EnableStars(false);
		}
	}

	private void InitialiseTestData()
	{
		int termID = 0;
		CharacterData.termStartDate = new CQDate("27-01-2014");
		CharacterData.termEndDate = new CQDate("17-04-2014");

		TimeSpan timeSpan = CharacterData.termStartDate - CharacterData.termEndDate;

		CharacterData.weeksInTerm = Math.Abs(Mathf.FloorToInt((float)timeSpan.Days / 7.0f));

		int daysInTerm = CharacterData.weeksInTerm * 7;

		CQDate incDate = CharacterData.termStartDate.Clone();
		string attendance = "";

		int dayOfWeek = 0;
		int i = 0;
		for (; i < daysInTerm; ++i, ++incDate, ++dayOfWeek)
		{
			if (dayOfWeek > 0)
			{
				if (i == 2 || i == 10 )
				{
					continue;
				}

				if (dayOfWeek % 5 == 0)
				{
					continue;
				}
				if (dayOfWeek % 6 == 0)
				{
					dayOfWeek = -1;
					continue;
				}
			}

			attendance += incDate;

			if (i < daysInTerm - 2)
			{
				attendance += "\n";
			}
		}

		// Split the massive attendance string into separate dates
		string[] attendanceDates = Regex.Split(attendance, "\n");

		// Add each date attended to character data attendance
		foreach (string date in attendanceDates)
		{
			if (date == "")
				continue;

			CharacterData.Attendance.Add(new CQDate(date));
		}
	}
}
