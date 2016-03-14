﻿// Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Words. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////

using Aspose.Words;
using Aspose.Words.Saving;

using NUnit.Framework;

namespace ApiExamples
{
    using Aspose.Pdf.Facades;
    using Aspose.Pdf.Text;

    [TestFixture]
    internal class ExPdfSaveOptions : ApiExampleBase
    {
        [Test]
        public void CreateMissingOutlineLevelsEx()
        {
            //ExStart
            //ExFor:Saving.PdfSaveOptions.OutlineOptions.CreateMissingOutlineLevels
            //ExSummary:Shows how to create missing outline levels saving the document in pdf
            Document doc = new Document();

            DocumentBuilder builder = new DocumentBuilder(doc);

            // Creating TOC entries
            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading1;

            builder.Writeln("Heading 1");

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading4;

            builder.Writeln("Heading 1.1.1.1");
            builder.Writeln("Heading 1.1.1.2");

            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading9;

            builder.Writeln("Heading 1.1.1.1.1.1.1.1.1");
            builder.Writeln("Heading 1.1.1.1.1.1.1.1.2");

            //Create "PdfSaveOptions" with some mandatory parameters
            //"HeadingsOutlineLevels" specifies how many levels of headings to include in the document outline
            //"CreateMissingOutlineLevels" determining whether or not to create missing heading levels
            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();

            pdfSaveOptions.OutlineOptions.HeadingsOutlineLevels = 9;
            pdfSaveOptions.OutlineOptions.CreateMissingOutlineLevels = true;
            pdfSaveOptions.SaveFormat = SaveFormat.Pdf;

            doc.Save(MyDir + "CreateMissingOutlineLevels.pdf", pdfSaveOptions);
            //ExEnd
        }


        //ToDo: unit "CreateMissingOutlineLevels" with "CreateMissingOutlineLevelsEx"
        [Test]
        public void CreateMissingOutlineLevels()
        {
            Document doc = DocumentHelper.CreateDocumentFillWithDummyText();

            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();

            //Set maximum value of levels of headings
            pdfSaveOptions.OutlineOptions.HeadingsOutlineLevels = 9;
            pdfSaveOptions.OutlineOptions.CreateMissingOutlineLevels = true;
            pdfSaveOptions.OutlineOptions.ExpandedOutlineLevels = 9;

            pdfSaveOptions.SaveFormat = SaveFormat.Pdf;

            doc.Save(MyDir + "CreateMissingOutlineLevels_OUT.pdf", pdfSaveOptions);

            //Bind pdf with Aspose PDF
            PdfBookmarkEditor bookmarkEditor = new PdfBookmarkEditor();
            bookmarkEditor.BindPdf(MyDir + "CreateMissingOutlineLevels_OUT.pdf");

            //Get all bookmarks from the document
            Bookmarks bookmarks = bookmarkEditor.ExtractBookmarks();

            Assert.AreEqual(9, bookmarks.Count);
        }

        //Note: Test doesn't containt validation result, because it's difficult
        //For validation result, you can add some shapes to the document and assert, that the DML shapes are render correctly
        [Test]
        public void DrawingMl()
        {
            Document doc = DocumentHelper.CreateDocumentFillWithDummyText();

            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.DmlRenderingMode = DmlRenderingMode.DrawingML;

            doc.Save(MyDir + "DrawingMl_OUT.pdf", pdfSaveOptions);
        }

        [Test]
        public void WithoutUpdateFields()
        {
            Document doc = DocumentHelper.CreateDocumentFillWithDummyText();

            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.UpdateFields = false;

            doc.Save(MyDir + "UpdateFields_False_OUT.pdf", pdfSaveOptions);

            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(MyDir + "UpdateFields_False_OUT.pdf");

            //Get text fragment by search string
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("Page  of");
            pdfDocument.Pages.Accept(textFragmentAbsorber);

            //Assert that fields are not updated
            Assert.AreEqual("Page  of", textFragmentAbsorber.TextFragments[1].Text);
        }

        [Test]
        public void WithUpdateFields()
        {
            Document doc = DocumentHelper.CreateDocumentFillWithDummyText();

            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.UpdateFields = true;

            doc.Save(MyDir + "UpdateFields_False_OUT.pdf", pdfSaveOptions);

            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(MyDir + "UpdateFields_False_OUT.pdf");

            //Get text fragment by search string
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber("Page 1 of 2");
            pdfDocument.Pages.Accept(textFragmentAbsorber);

            //Assert that fields are updated
            Assert.AreEqual("Page 1 of 2", textFragmentAbsorber.TextFragments[1].Text);
        }
    }
}
