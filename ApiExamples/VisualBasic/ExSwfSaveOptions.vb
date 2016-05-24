' Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Words. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////


Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Words
Imports Aspose.Words.Saving

Imports NUnit.Framework

Namespace ApiExamples
	<TestFixture> _
	Public Class ExSwfSaveOptions
		Inherits ApiExampleBase
		<Test> _
		Public Sub UseCustomToolTips()
			Dim doc As New Document(MyDir & "Document.doc")

			'ExStart
			'ExFor:SwfSaveOptions
			'ExFor:SwfSaveOptions.ToolTipsFontName
			'ExFor:SwfSaveOptions.ToolTips
			'ExFor:SwfViewerControlIdentifier
			'ExSummary:Shows how to change the the tooltips used in the embedded document viewer.
			' We create an instance of SwfSaveOptions to specify our custom tooltips.
			Dim options As New SwfSaveOptions()

			' By default, all tooltips are in English. You can specify font used for each tooltip.
			' Note that font specified should contain proper glyphs normally used in tooltips.
			options.ToolTipsFontName = "Times New Roman"

			' The following code will set the tooltip used for each control. In our case we will change the tooltips from English
			' to Russian.
			options.ToolTips(SwfViewerControlIdentifier.TopPaneActualSizeButton) = "������������ ������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneFitToHeightButton) = "�� ������ ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneFitToWidthButton) = "�� ������ ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneZoomOutButton) = "���������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneZoomInButton) = "��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneSelectionModeButton) = "����� ��������� ������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneDragModeButton) = "����� ��������������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneSinglePageScrollLayoutButton) = "�������������� ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneSinglePageLayoutButton) = "�������������� �����"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneTwoPageScrollLayoutButton) = "������������� ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneTwoPageLayoutButton) = "������������� �����"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneFullScreenModeButton) = "������������� �����"
			options.ToolTips(SwfViewerControlIdentifier.TopPanePreviousPageButton) = "���������� ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPanePageField) = "������� ����� ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneNextPageButton) = "��������� ��������"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneSearchField) = "������� ������� �����"
			options.ToolTips(SwfViewerControlIdentifier.TopPaneSearchButton) = "������"

			' Left panel.
			options.ToolTips(SwfViewerControlIdentifier.LeftPaneDocumentMapButton) = "����� ���������"
			options.ToolTips(SwfViewerControlIdentifier.LeftPanePagePreviewPaneButton) = "��������������� �������� �������"
			options.ToolTips(SwfViewerControlIdentifier.LeftPaneAboutButton) = "� ����������"
			options.ToolTips(SwfViewerControlIdentifier.LeftPaneCollapsePanelButton) = "�������� ������"

			' Bottom panel.
			options.ToolTips(SwfViewerControlIdentifier.BottomPaneShowHideBottomPaneButton) = "��������/������ ������"
			'ExEnd

			doc.Save(MyDir & "\Artifacts\SwfSaveOptions.ToolTips.swf", options)
		End Sub

		<Test> _
		Public Sub HideControls()
			'ExStart
			'ExFor:SwfSaveOptions.TopPaneControlFlags
			'ExFor:SwfTopPaneControlFlags
			'ExFor:SwfSaveOptions.ShowSearch
			'ExSummary:Shows how to choose which controls to display in the embedded document viewer.
			Dim doc As New Document(MyDir & "Document.doc")

			' Create an instance of SwfSaveOptions and set some buttons as hidden.
			Dim options As New SwfSaveOptions()
			' Hide all the buttons with the exception of the page control buttons. Similar flags can be used for the left control pane as well.
			options.TopPaneControlFlags = SwfTopPaneControlFlags.HideAll Or SwfTopPaneControlFlags.ShowActualSize Or SwfTopPaneControlFlags.ShowFitToWidth Or SwfTopPaneControlFlags.ShowFitToHeight Or SwfTopPaneControlFlags.ShowZoomIn Or SwfTopPaneControlFlags.ShowZoomOut

			' You can also choose to show or hide the main elements of the viewer. Hide the search control.
			options.ShowSearch = False
			'ExEnd

			doc.Save(MyDir & "\Artifacts\SwfSaveOptions.HideControls.swf", options)
		End Sub

		<Test> _
		Public Sub SetLogo()
			Dim doc As New Document(MyDir & "Document.doc")

			'ExStart
			'ExFor:SwfSaveOptions.#ctor
			'ExFor:SwfSaveOptions
			'ExFor:SwfSaveOptions.LogoImageBytes
			'ExFor:SwfSaveOptions.LogoLink
			'ExSummary:Shows how to specify a custom logo and link it to a web address in the embedded document viewer.
			' Create an instance of SwfSaveOptions.
			Dim options As New SwfSaveOptions()

			' Read the image into byte array.
			Dim logoBytes() As Byte = File.ReadAllBytes(MyDir & "LogoSmall.png")

			' Specify the logo image to use.
			options.LogoImageBytes = logoBytes

			' You can specify the URL of web page that should be opened when you click on the logo.
			options.LogoLink = "http://www.aspose.com"
			'ExEnd

			doc.Save(MyDir & "\Artifacts\SwfSaveOptions.CustomLogo.swf", options)
		End Sub

	End Class
End Namespace
