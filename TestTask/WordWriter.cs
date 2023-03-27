using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace TestTask
{
    internal static class WordWriter
    {
        static Word.Application App { get; set; }
        static Word.Document Document { get; set; }
        static Word.Paragraph Paragraph { get; set; }
        static WordWriter()
        {
            App = new Word.Application();
            Document = App.Documents.Add(Visible: true);
            Paragraph = Document.Paragraphs.Add();
        }

        public static void WriteParagraph(string str, bool bold = false, int fontSize = 11)
        {
            Paragraph = Document.Paragraphs.Add();
            Word.Range Range = Paragraph.Range;
            if (bold)
                Range.Bold = 1;
            Range.Font.Size = fontSize;
            Range.Text = str;
            Range.InsertParagraphAfter();
        }

        public static void WriteTable(List<Cu> list)
        {
            Paragraph = Document.Paragraphs.Add();
            Word.Range Range = Paragraph.Range;
            int[] columnWidth = { 30, 50, 60, 250, 75 };
            string[] columnNames = { "№", "Тип", "Код", "Имя", "ИНН" };

            Word.Table t = Document.Tables.Add(Range, list.Count, 5);
            t.Borders.Enable = 1;
            for (int i = 0; i < 5; i++)
            {
                t.Cell(1, i + 1).Column.Width = columnWidth[i];
                t.Cell(1, i + 1).Range.Text = columnNames[i];
            }

            for (int i = 0; i < list.Count; i++)
            {
                t.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                t.Cell(i + 2, 2).Range.Text = list[i].type;
                t.Cell(i + 2, 3).Range.Text = list[i].code;
                t.Cell(i + 2, 4).Range.Text = list[i].name;
                t.Cell(i + 2, 5).Range.Text = list[i].soun.inn;
            }
        }

        public static void Close()
        {
            Document.Close();
            App.Quit();
        }
    }
}
