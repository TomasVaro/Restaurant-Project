using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Projektarbetet
{
    class MyForm : Form
    {
        public MyForm()
        {
            Size = new Size(700, 500);      //anger storleken på fönstret
            {

                TableLayoutPanel table = new TableLayoutPanel
                {
                    RowCount = 8,
                    ColumnCount = 3,
                    Dock = DockStyle.Fill,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset
                };
                Controls.Add(table);

                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 13));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 13));

                Label restaurantName = new Label
                {
                    Text = "Restaurang SeeCharp",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Brush Script Std", 30),
                    AutoSize = true
                };
                table.Controls.Add(restaurantName);
                table.SetColumnSpan(restaurantName, 3);

                ComboBox starter = new ComboBox
                {                    
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Dock = DockStyle.Fill,
                };
                table.Controls.Add(starter);
                //starter.SelectedIndexChanged += ComboboxChanged;
            }            
        }
    }
}
