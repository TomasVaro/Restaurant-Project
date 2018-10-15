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
            Text = "Restaurant SeeSharp";
            Size = new Size(700, 500);      //anger storleken på fönstret


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
                Font = new Font("Times New Roman", 30),
                AutoSize = true
            };
            table.Controls.Add(restaurantName);
            table.SetColumnSpan(restaurantName, 3);

            Label menu = new Label
            {
                Text = "Meny",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill

            };
            table.Controls.Add(menu, 0, 1);

            ComboBox starter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Förrätter"
            };
            table.Controls.Add(starter, 0, 2);

            ComboBox warmDishes = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Varmrätter"
            };
            table.Controls.Add(warmDishes, 0, 3);

            ComboBox deserts = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Efterrätter"
            };
            table.Controls.Add(deserts, 0, 4);

            ComboBox drinks = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Dricker"
            };
            table.Controls.Add(drinks, 0, 5);

            PictureBox picture = new PictureBox
            {
                Image = Image.FromFile("pic1.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Width = 150,
                Height = 150
            };
            table.Controls.Add(picture, 1, 1);
            table.SetRowSpan(picture, 3);
            //starter.SelectedIndexChanged += ComboboxChanged;

            TextBox description = new TextBox
            {
                Multiline = true,
                Width = 100,
                Height = 150,
                Dock = DockStyle.Fill

            };
            table.Controls.Add(description, 1, 4);
            table.SetRowSpan(description, 2);

            Button add = new Button
            {
                Text = "Lägg till",
                Dock = DockStyle.Fill,
                Font = new Font("Times New Roman", 14)

            };
            table.Controls.Add(add, 1, 6);

            Button remove = new Button
            {
                Text = "Ta bort",
                Font = new Font("Times New Roman", 14),

                Dock = DockStyle.Fill
            };
            table.Controls.Add(remove, 1, 7);

            Label order = new Label
            {
                Text = "Beställning",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill

            };
            table.Controls.Add(order, 2, 1);

            TextBox orderList = new TextBox
            {
                Multiline = true,
                Width = 100,
                Height = 150,
                Dock = DockStyle.Fill

            };
            table.Controls.Add(orderList, 2, 2);
            table.SetRowSpan(orderList, 4);

            Label totalPrice = new Label
            {
                Text = "Pris totalt:",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill

            };
            table.Controls.Add(totalPrice, 2, 6);

            Button shop = new Button
            {
                Text = "Beställ",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            table.Controls.Add(shop, 2, 7);


        }





    }
}
