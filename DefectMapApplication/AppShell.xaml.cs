﻿namespace DefectMapApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DefectListDetailPage), typeof(DefectListDetailPage));
	}
}