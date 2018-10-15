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
                RowCount = 12,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset
            };
            Controls.Add(table);

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));

            Label restaurantName = new Label
            {
                Text = "Restaurang SeeSharp",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Lucida Console", 30),
            };
            table.Controls.Add(restaurantName);
            table.SetColumnSpan(restaurantName, 3);

            Label menu = new Label
            {
                Text = "Meny",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            table.Controls.Add(menu, 0, 1);

            Label startersLabel = new Label
            {
                Text = "Förrätter",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            table.Controls.Add(startersLabel, 0, 2);

            ComboBox starter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
            };
            table.Controls.Add(starter, 0, 3);
            //starter.SelectedIndexChanged += ComboboxChanged;

            Label warmDishesLabel = new Label
            {
                Text = "Varmrätter",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            table.Controls.Add(warmDishesLabel, 0, 4);


            ComboBox warmDishes = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Varmrätter"
            };
            table.Controls.Add(warmDishes, 0, 5);
            //warmDishes.SelectedIndexChanged += ComboboxChanged

            Label dessertsLabel = new Label
            {
                Text = "Efterrätter",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            table.Controls.Add(dessertsLabel, 0, 6);


            ComboBox desserts = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Efterrätter"
            };
            table.Controls.Add(desserts, 0, 7);
            //desserts.SelectedIndexChanged += ComboboxChanged;

            Label drinksLabel = new Label
            {
                Text = "Dricka",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            table.Controls.Add(drinksLabel, 0, 8);


            ComboBox drinks = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Dricka"
            };
            table.Controls.Add(drinks, 0, 9);
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
            table.SetRowSpan(picture, 6);


            TextBox boxDescription = new TextBox
            {
                Multiline = true,
                Width = 100,
                Height = 150,
                Dock = DockStyle.Fill
            };
            table.Controls.Add(boxDescription, 1, 7);
            table.SetRowSpan(boxDescription, 3);


            Button add = new Button
            {
                Text = "Lägg till",
                Dock = DockStyle.Fill,
                Font = new Font("Times New Roman", 14)
            };
            table.Controls.Add(add, 1, 10);


            Button remove = new Button
            {
                Text = "Ta bort",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            table.Controls.Add(remove, 1, 11);


            Label order = new Label
            {
                Text = "Beställning",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
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
            table.SetRowSpan(orderList, 8);


            Label totalPrice = new Label
            {
                Text = "Pris totalt:",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            table.Controls.Add(totalPrice, 2, 10);


            Button shop = new Button
            {
                Text = "Beställ",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            table.Controls.Add(shop, 2, 11);

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
                starter.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in listWarmDishes)
            {
                warmDishes.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in listDesserts)
            {
                desserts.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in listDrinks)
            {
                drinks.Items.Add(p.Name + " - " + p.Price + " kr");
            };


        }
    }
}
