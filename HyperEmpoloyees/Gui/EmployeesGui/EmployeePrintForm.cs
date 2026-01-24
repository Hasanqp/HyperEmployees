//using DocumentFormat.OpenXml.Spreadsheet;
using HyperEmpoloyees.Core;
using System.Drawing.Printing;

namespace HyperEmpoloyees.Gui.EmployeesGui
{
    public partial class EmployeePrintForm : Form
    {
        private PrintDocument printDocument;
        private DataGridView _grid;

        private int currentRowIndex = 0;
        private bool isColorPrint = false;
        private bool isNewPage = true;

        private List<DataGridViewColumn> visibleColumns = new();
        private int columnWidth;
        public EmployeePrintForm(DataGridView grid)
        {
            InitializeComponent();
            _grid = grid;

            printDocument = new PrintDocument();
            printDocument.PrintPage += printDocumentPrintPage_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true;
        }

        private void printDocumentPrintPage_PrintPage(object sender, PrintPageEventArgs e)
        {
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int rowHeight = 40;

            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 10);

            Brush brush = isColorPrint ? Brushes.DarkBlue : Brushes.Black;
            Pen pen = isColorPrint ? Pens.DarkBlue : Pens.Black;

            int x = leftMargin;
            int y = topMargin;

            // ================= TITLE =================
            if (isNewPage)
            {
                e.Graphics.DrawString(
                    "Employees List",
                    new Font("Arial", 18, FontStyle.Bold),
                    brush,
                    leftMargin,
                    y
                );

                y += 50;

                // ================= HEADERS =================
                int printableWidth = e.MarginBounds.Width;

                visibleColumns = _grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .ToList();

                columnWidth = (printableWidth / visibleColumns.Count) + 3;

                foreach (var col in visibleColumns)
                {
                    e.Graphics.DrawRectangle(pen, x, y, columnWidth, rowHeight);

                    RectangleF headerRect = new RectangleF(
                        x + 3,
                        y + 3,
                        columnWidth - 6,
                        rowHeight - 6
                    );

                    StringFormat headerFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Near,
                        Trimming = StringTrimming.EllipsisCharacter
                    };

                    e.Graphics.DrawString(
                        col.HeaderText,
                        headerFont,
                        brush,
                        headerRect,
                        headerFormat
                    );

                    x += columnWidth;
                }

                y += rowHeight;
                x = leftMargin;
                isNewPage = false;
            }

            // ================= ROWS =================
            while (currentRowIndex < _grid.Rows.Count)
            {
                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                DataGridViewRow row = _grid.Rows[currentRowIndex];

                foreach (var col in visibleColumns)
                {
                    string value = row.Cells[col.Index].Value?.ToString() ?? "";

                    e.Graphics.DrawRectangle(pen, x, y, columnWidth, rowHeight);

                    RectangleF cellRect = new RectangleF(
                        x + 3,
                        y + 3,
                        columnWidth - 6,
                        rowHeight - 6
                    );

                    StringFormat cellFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter
                    };

                    e.Graphics.DrawString(
                        value,
                        cellFont,
                        brush,
                        cellRect,
                        cellFormat
                    );

                    x += columnWidth;
                }

                x = leftMargin;
                y += rowHeight;
                currentRowIndex++;
            }

            // ================= END =================
            currentRowIndex = 0;
            isNewPage = true;
            e.HasMorePages = false;
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            comboBoxColor.SelectedIndex = 0;

            if (comboBoxColor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select print color mode");
                return;
            }

            isColorPrint = comboBoxColor.SelectedIndex == 1;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument;
            preview.Width = 1000;
            preview.Height = 700;
            preview.ShowDialog();
        }
    }
}
