using System;
using System.Globalization;

namespace Bloom.Pages;

public partial class CalendarPage : ContentPage
{
	private DateTime currDate;
	public CalendarPage()
	{
		InitializeComponent();
		currDate = DateTime.Now;
		BuildCalendar(currDate);
	}

	private void BuildCalendar(DateTime currentDate)
	{
		string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentDate.Month);
		MonthYearLabel.Text = $"{monthName} {currentDate.Year}";

		DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
		int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

		int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

		CalendarGrid.Children.Clear();
		CalendarGrid.RowDefinitions.Clear();
		CalendarGrid.ColumnDefinitions.Clear();

		for (int i = 0; i < 6; i++)
		{
			CalendarGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
		}

        for (int i = 0; i < 7; i++)
        {
            CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

		int dayCounter = 1;

		for (int row = 0; row < 6; row++)
		{
			for (int column = 0; column < 7; column++)
			{
				if(row == 0 && column < startDayOfWeek)
				{
					continue;
				}

				if (dayCounter <= daysInMonth)
				{
					Label dayLabel = new Label
					{
						Text = dayCounter.ToString(),
						FontSize = 18,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						Padding = new Thickness(10)
					};
					CalendarGrid.Children.Add(dayLabel);
					Grid.SetRow(dayLabel, row);
					Grid.SetColumn(dayLabel, column);
					dayCounter++;
				}
			}
		}
    }

	private void swipedLeft(object sender, SwipedEventArgs e)
	{
		currDate = currDate.AddMonths(1);
		BuildCalendar(currDate);
	}

    private void swipedRight(object sender, SwipedEventArgs e)
    {
        currDate = currDate.AddMonths(-1);
        BuildCalendar(currDate);
    }
}