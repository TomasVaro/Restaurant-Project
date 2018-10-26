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
        public Dictionary<string, int> TotalOrderDictionary;
        public int TotalPrice;
        public Label totalPriceLabel;
        public string orderNamePrice;
        public string orderPrice;
        public string[] orderArray;
        public int DataGridViewRowIndex;
        public int DataGridViewColumnIndex;


        public class Product
        {
            public string Index;
            public int Price;
            public string Name;
            public string Description;
        };

        public MyForm()
        {
            TotalOrderDictionary = new Dictionary<string, int>();
            TotalPrice = 0;

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
                Font = new Font("Blackoak Std", 22),
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
                Font = new Font("Times New Roman", 18)               
            };
            Table.Controls.Add(DescriptionBox, 1, 7);
            Table.SetRowSpan(DescriptionBox, 2);
            DescriptionBox.ReadOnly = true;


            Button add = new Button
            {
                Text = "Lägg till",
                Dock = DockStyle.Fill,
                Font = new Font("Times New Roman", 14)
            };
            Table.Controls.Add(add, 1, 9);
            add.Click += AddClick;


            Button remove = new Button
            {
                Text = "Ta bort",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(remove, 1, 10);
            remove.Click += RemoveClick;


            Button clearChart = new Button
            {
                Text = "Rensa beställningen",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(clearChart, 1, 11);
            clearChart.Click += ClearChartClick;



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
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            Table.Controls.Add(orderList, 2, 2);
            Table.SetRowSpan(orderList, 7);
            orderList.Columns[0].Name = "Antal";
            orderList.Columns[1].Name = "Maträtt";
            orderList.Columns[2].Name = "Pris/st";
            orderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;            
            orderList.CellClick += OrderListClick;


            totalPriceLabel = new Label
            {
                Text = "Pris totalt:",
                Font = new Font("Times New Roman", 14),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(totalPriceLabel, 2, 9);


            Button shop = new Button
            {
                Text = "Beställ",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(shop, 2, 10);


            Button saveOrder = new Button
            {
                Text = "Spara beställningen",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(saveOrder, 2, 11);
            saveOrder.Click += SaveOrderClick;



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
            }
        }




        // Lägger till bild i PictureBox och beskrivning i DescriptionBox när man väljer från dropdown-listorna.
        private void ComboboxChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            ComboBoxClickItem = Convert.ToString(c.SelectedItem);   // Vald rätt sparas i ComboBoxClickItem

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



        // Lägger till beställningen till DataGridView.
        private void AddClick(object sender, EventArgs e)
        {
            if (ComboBoxClickItem != null)  // Kollar om man valt någon rätt eller inte.
            {                
                // Lägger till beställningen i dictionary TotalOrderDictionary.
                if (TotalOrderDictionary.ContainsKey(ComboBoxClickItem))
                {
                    TotalOrderDictionary[ComboBoxClickItem] += 1;
                }
                else
                {
                    TotalOrderDictionary[ComboBoxClickItem] = 1;
                }

                // Lägger till priset i "Pris totalt"-rutan.
                string[] orderArray = ComboBoxClickItem.Split(new char[] { '-' });
                int price = int.Parse(orderArray[1].Replace(" kr", string.Empty));
                TotalPrice += price;
                totalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";


                orderList.Rows.Clear();            
                // Lägger till antal, namn och pris till DataGridView samt priset till TotalPrice
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    string order = pair.Key;
                    orderArray = order.Split(new char[] { '-' });
                    orderList.Rows.Add(pair.Value, orderArray[0], orderArray[1]);
                    orderList.Name = orderArray[0];                    
                }
                orderList.CurrentCell.Selected = false; // Tar bort automatiska cellmarkeringen i DatGridView
            }
        }



        // Hämtar namnet och priset på maträtten från DataGridView.
        private void OrderListClick(object sender, EventArgs e)
        {
            DataGridViewRowIndex = orderList.CurrentRow.Index; // Ger index på raden som markerats
            DataGridViewColumnIndex = orderList.CurrentCell.ColumnIndex;    // Ger index på columnen som markerats
            string orderName = orderList.CurrentRow.Cells[1].Value.ToString();
            orderPrice = orderList.CurrentRow.Cells[2].Value.ToString();
            orderNamePrice = orderName + "-" + orderPrice;
        }



        // Tar bort beställningen från DataGridView.
        private void RemoveClick(object sender, EventArgs e)
        {
            if (TotalOrderDictionary.Count > 0) // Kollar om det finns något i TotalOrderDictionary.
            {
                if (orderNamePrice != null) // Kollar att orderNamePrice inte är null.
                {
                    string productInGrid = Convert.ToString(orderList.Rows[0].Cells["Maträtt"].Value);
                    string priceInGrid = Convert.ToString(orderList.Rows[0].Cells["Pris/st"].Value);
                    string productPriceInGrid = productInGrid + "-" + priceInGrid;

                    if(TotalOrderDictionary.ContainsKey(orderNamePrice))
                    {
                        TotalOrderDictionary[orderNamePrice] -= 1;

                        // Subtraherar priset från "Pris totalt"-rutan.
                        orderArray = ComboBoxClickItem.Split(new char[] { '-' });
                        int price = int.Parse(orderPrice.Replace(" kr", string.Empty));
                        TotalPrice -= price;
                        totalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";                    
                    }
                }

                // Om antalet av en beställning blir 0 så tas den bort.
                foreach (var item in TotalOrderDictionary.Where(KeyValuePair => KeyValuePair.Value == 0).ToList())
                {
                    TotalOrderDictionary.Remove(item.Key);
                }

                // Lägger till antal, namn och pris till DataGridView.
                orderList.Rows.Clear();
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    string order = pair.Key;
                    orderArray = order.Split(new char[] { '-' });
                    orderList.Rows.Add(pair.Value, orderArray[0], orderArray[1]);
                }

                //Här skall koden in som avmarkerar cellen
                //orderList.Rows[DataGridViewRowIndex].Cells[DataGridViewColumnIndex].Selected = false;


                // Om TotalOrderDictionary inte är tom tas den automatiska cellmarkeringen bort i DataGrid View
                if (TotalOrderDictionary.Count != 0)
                {
                    orderList.CurrentCell.Selected = false; // Tar bort cellmarkeringen i DatGridView.
                }

                // Sparar markeringen i cellen om inte raden i DataGridView tagits bort
                if(DataGridViewRowIndex < TotalOrderDictionary.Count)
                {
                    orderList.CurrentCell.Selected = false; // Ta ej bort denna!! Tar bort automatiska cellmarkeringen i DatGridView
                    orderList.Rows[DataGridViewRowIndex].Cells[DataGridViewColumnIndex].Selected = true;
                }               
            }

        }



        // Rensar hela beställningen.
        private void ClearChartClick(object sender, EventArgs e)
        {
            orderList.Rows.Clear();
            TotalOrderDictionary.Clear();
            TotalPrice = 0;
            totalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";
        }



        // Sparar beställningen i en fil.
        private void SaveOrderClick(object sender, EventArgs e)
        {
            string csv = string.Join(Environment.NewLine, TotalOrderDictionary.Select(d => d.Key + "," + d.Value));
            System.IO.File.WriteAllText(@"C:\Temp\Cart.csv", csv);
            MessageBox.Show("Din varukorg är sparad!");
            orderList.Rows.Clear();
            TotalOrderDictionary.Clear();
            TotalPrice = 0;
            totalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";
        }
    }
            // MessageBox.Show(orderNamePrice);
}