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
        public class Product
        {
            public string Index;
            public int Price;
            public string Name;
            public string Description;
        };
        public MyForm()
        {
           WindowState = FormWindowState.Maximized;      //anger storleken på fönstret


            TableLayoutPanel table = new TableLayoutPanel
            {
                RowCount = 9,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset
            };
            Controls.Add(table);

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12));

            Label restaurantName = new Label
            {
                Text = "Restaurang SeeShark",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Lucida Console", 30),
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
            
            //starter.SelectedIndexChanged += ComboboxChanged;


            ComboBox warmDishes = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Varmrätter"
            };
            table.Controls.Add(warmDishes, 0, 3);
            //warmDishes.SelectedIndexChanged += ComboboxChanged


            ComboBox deserts = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Efterrätter"
            };
            table.Controls.Add(deserts, 0, 4);
            //deserts.SelectedIndexChanged += ComboboxChanged;


            ComboBox drinks = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Dricka"
            };
            table.Controls.Add(drinks, 0, 5);
            //drinks.SelectedIndexChanged += ComboboxChanged;

            /*
            Label childMenue = new Label
            {
                Text = "Barnmeny på varmrätter för halva priset!",
                Font = new Font("Times New Roman", 16),
                Dock = DockStyle.Fill
            };
            table.Controls.Add(childMenue, 0, 7);
            */


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


            TextBox boxDescription = new TextBox
            {
                Multiline = true,
                Width = 100,
                Height = 150,
                Dock = DockStyle.Fill

            };
            table.Controls.Add(boxDescription, 1, 4);
            table.SetRowSpan(boxDescription, 2);


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

            List<Product> listStarters = new List<Product>();
            List<Product> listWarmDishes = new List<Product>();
            List<Product> listDesserts = new List<Product>();
            List<Product> listDrinks = new List<Product>();

            string[] lines = File.ReadAllLines("products.csv");
            
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string index = parts[0];
                int price = int.Parse(parts[1]);
                string name = parts[2];
                string description = parts[3];

                if (index.StartsWith("s"))
                {
                    listStarters.Add(new Product
                    {
                        Price = price,
                        Name = name,
                        Description = description
                    });

                }
                else if (index.StartsWith("w"))
                {
                    listWarmDishes.Add(new Product
                    {
                        Price = price,
                        Name = name,
                        Description = description
                    });
                }
                else if (index.StartsWith("d"))
                {
                    listDesserts.Add(new Product
                    {
                        Price = price,
                        Name = name,
                        Description = description
                    });
                }
                else if (index.StartsWith("f"))
                {
                    listDrinks.Add(new Product
                    {
                        Price = price,
                        Name = name,
                        Description = description
                    });
                }






            }
            foreach (Product p in listStarters)
            {
                string info = (p.Name + " "+ p.Price + " kr");
                starter.Items.Add(info);
            };




        }
    }
}
