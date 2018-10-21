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

        public TableLayoutPanel Table;
        public ComboBox Starters;
        public ComboBox WarmDishes;
        public ComboBox Desserts;
        public ComboBox Drinks;
        public PictureBox Picture;
        public TextBox DescriptionBox;
        public List<Product> listStarters;
        public DataGridView orderList;
        public string ComboBoxClickItem;

        public class Product
        {
            public string Index;
            public int Price;
            public string Name;
            public string Description;
        };

        public MyForm()
        {
            // Anger storleken på fönstret.
            WindowState = FormWindowState.Maximized;

            Table = new TableLayoutPanel
            {
                RowCount = 12,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset
            };
            Controls.Add(Table);

            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44));
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));


            Label restaurantName = new Label
            {
                Text = "Restaurang SeaSharp",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Lucida Console", 30),
            };
            Table.Controls.Add(restaurantName);
            Table.SetColumnSpan(restaurantName, 3);


            Label menuLabel = new Label
            {
                Text = "Meny",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Table.Controls.Add(menuLabel, 0, 1);


            Label startersLabel = new Label
            {
                Text = "Förrätter",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            Table.Controls.Add(startersLabel, 0, 2);


            Starters = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
            };
            Table.Controls.Add(Starters, 0, 3);
            Starters.SelectedIndexChanged += ComboboxChanged;


            Label warmDishesLabel = new Label
            {
                Text = "Varmrätter",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            Table.Controls.Add(warmDishesLabel, 0, 4);


            WarmDishes = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Varmrätter"
            };
            Table.Controls.Add(WarmDishes, 0, 5);
            WarmDishes.SelectedIndexChanged += ComboboxChanged;
            

            Label dessertsLabel = new Label
            {
                Text = "Efterrätter",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            Table.Controls.Add(dessertsLabel, 0, 6);


            Desserts = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Efterrätter"
            };
            Table.Controls.Add(Desserts, 0, 7);
            Desserts.SelectedIndexChanged += ComboboxChanged;


            Label drinksLabel = new Label
            {
                Text = "Dricka",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            Table.Controls.Add(drinksLabel, 0, 8);


            Drinks = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                Text = "Dricka"
            };
            Table.Controls.Add(Drinks, 0, 9);
            Drinks.SelectedIndexChanged += ComboboxChanged;


            Label discountLabel = new Label
            {
                Text = "Skriv in ev. rabattkod:",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };
            Table.Controls.Add(discountLabel, 0, 10);


            TextBox discount = new TextBox
            {
                Dock = DockStyle.Fill                
            };
            Table.Controls.Add(discount, 0, 11);

            /*
            Label childMenue = new Label
            {
                Text = "Barnmeny på varmrätter för halva priset!",
                Font = new Font("Times New Roman", 16),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(childMenue, 0, 7);
            */


            // Slumpar fram restaurang-bilderna
            Random rnd = new Random();
            int rndPicture = rnd.Next(1, 4);
            Picture = new PictureBox
            {
                Image = Image.FromFile("pic" + rndPicture + ".jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Width = 150,
                Height = 150
            };
            Table.Controls.Add(Picture, 1, 1);
            Table.SetRowSpan(Picture, 6);


            DescriptionBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                Font = new Font("Times New Roman", 18),
            };
            Table.Controls.Add(DescriptionBox, 1, 7);
            Table.SetRowSpan(DescriptionBox, 3);
            DescriptionBox.ReadOnly = true;


            Button add = new Button
            {
                Text = "Lägg till",
                Dock = DockStyle.Fill,
                Font = new Font("Times New Roman", 14)
            };
            Table.Controls.Add(add, 1, 10);
            add.Click += AddClick;


            Button remove = new Button
            {
                Text = "Ta bort",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(remove, 1, 11);


            Label order = new Label
            {
                Text = "Beställning",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Table.Controls.Add(order, 2, 1);


            orderList = new DataGridView
            {
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false
            };
            Table.Controls.Add(orderList, 2, 2);
            Table.SetRowSpan(orderList, 8);
            orderList.Columns[0].Name = "Antal";
            orderList.Columns[1].Name = "Maträtt";
            orderList.Columns[2].Name = "Pris";
            orderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        
            Label totalPrice = new Label
            {
                Text = "Pris totalt:",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(totalPrice, 2, 10);


            Button shop = new Button
            {
                Text = "Beställ",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(shop, 2, 11);


            listStarters = new List<Product>();
            List<Product> listWarmDishes = new List<Product>();
            List<Product> listDesserts = new List<Product>();
            List<Product> listDrinks = new List<Product>();

            // Splittar produkterna och lägger i 4 olika listor.
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

            // Lägger till produkterna i dropdowlistorna.
            foreach (Product p in listStarters)
            {              
                Starters.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in listWarmDishes)
            {
                WarmDishes.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in listDesserts)
            {
                Desserts.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in listDrinks)
            {
                Drinks.Items.Add(p.Name + " - " + p.Price + " kr");
            };
        }


        private void ComboboxChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            ComboBoxClickItem = Convert.ToString(c.SelectedItem);   // Vald rätt sparas i instansvariabeln ComboBoxClickItem

            // Lägger till rätt bild i PictureBox.
            string index1 = "";
            if (sender == Starters)
            {
                index1 = "s";
            }
            else if (sender == WarmDishes)
            {
                index1 = "w";
            }
            else if (sender == Desserts)
            {
                index1 = "d";
            }
            else
            {
                index1 = "f";
            }
            Picture.Image = Image.FromFile(index1 + (c.SelectedIndex + 1) + ".jpg");

            
            // Lägger till rätt beskrivning i DescriptionBox.
            string[] lines = File.ReadAllLines("products.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string index = parts[0];
                string description = parts[3];

                if (index == index1 + (c.SelectedIndex + 1))
                {
                    DescriptionBox.Text = description;
                }
            }
        }


        private void AddClick(object sender, EventArgs e)
        {
            Button c = (Button)sender;                        
            int quantity = 0;
            quantity++;            
            string[] namePrisArray = ComboBoxClickItem.Split(new char[] { '-' });

            orderList.Rows.Add(new string[] { quantity.ToString(), namePrisArray[0], namePrisArray[1]});
        }
    }
}
