'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports Aspose.Cells.Charts
Imports System
Imports System.Drawing

Namespace UsingSparklines
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Instantiate a Workbook
			'Open a template file
			Dim book As New Workbook(dataDir & "Book1.xlsx")
			'Get the first worksheet
			Dim sheet As Worksheet = book.Worksheets(0)

			'Use the following lines if you need to read the Sparklines
			'Read the Sparklines from the template file (if it has)
			For Each g As SparklineGroup In sheet.SparklineGroupCollection
				'Display the Sparklines group information e.g type, number of sparklines items
				Console.WriteLine("sparkline group: type:" & g.Type & ", sparkline items count:" & g.SparklineCollection.Count)
				For Each s As Sparkline In g.SparklineCollection
					'Display the individual Sparkines and the data ranges
					Console.WriteLine("sparkline: row:" & s.Row & ", col:" & s.Column & ", dataRange:" & s.DataRange)
				Next s
			Next g


			'Add Sparklines
			'Define the CellArea D2:D10
			Dim ca As New CellArea()
			ca.StartColumn = 4
			ca.EndColumn = 4
			ca.StartRow = 1
			ca.EndRow = 7
			'Add new Sparklines for a data range to a cell area
			Dim idx As Integer = sheet.SparklineGroupCollection.Add(SparklineType.Column, "Sheet1!B2:D8", False, ca)
			Dim group As SparklineGroup = sheet.SparklineGroupCollection(idx)
			'Create CellsColor
			Dim clr As CellsColor = book.CreateCellsColor()
			clr.Color = Color.Orange
			group.SeriesColor = clr

			'Save the excel file
			book.Save(dataDir & "Book1_out.xlsx")

		End Sub
	End Class
End Namespace