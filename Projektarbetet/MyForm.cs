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
            public int Price;
            public string Name;
            public string Description;
        };

        public ComboBox Starters;
        public ComboBox WarmDishes;
        public ComboBox Desserts;
        public ComboBox Drinks;
        public PictureBox Picture;
        public TextBox DescriptionBox;
        public DataGridView OrderList;
        public Dictionary<string, int> TotalOrderDictionary;
        public Label TotalPriceLabel;
        public TextBox CustomerDiscountCode;
        public TableLayoutPanel Table;
        public List<Product> ListStarters;
        public List<Product> ListWarmDishes;
        public List<Product> ListDesserts;
        public List<Product> ListDrinks;
        public string ComboBoxClickItem;
        public int TotalPrice;
        public int TotalPriceWithDiscount;
        public string OrderNameAndPrice;
        public string OrderPrice;
        public string[] OrderArray;
        public int RndPicture;
        public string[] CartArray;
        public string[] ProductArray;
        public int Percentage;

        public MyForm()
        {
            Table = new TableLayoutPanel
            {
                RowCount = 12,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
            };
            Controls.Add(Table);
            WindowState = FormWindowState.Maximized;
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
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 9));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));
            Table.RowStyles.Add(new RowStyle(SizeType.Percent, 8));


            Label restaurantName = new Label
            {
                Text = "Restaurang SeaSharp",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Arial Black", 30),
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
                Font = new Font("Times New Roman", 14)
            };
            Table.Controls.Add(Starters, 0, 3);
            Starters.SelectedIndexChanged += ComboboxChanged;
            Starters.Click += StartersClick;


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
                Font = new Font("Times New Roman", 14)
            };
            Table.Controls.Add(WarmDishes, 0, 5);
            WarmDishes.SelectedIndexChanged += ComboboxChanged;
            WarmDishes.Click += WarmDishesClick;


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
                Font = new Font("Times New Roman", 14)
            };
            Table.Controls.Add(Desserts, 0, 7);
            Desserts.SelectedIndexChanged += ComboboxChanged;
            Desserts.Click += DessertsClick;


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
                Font = new Font("Times New Roman", 14)
            };
            Table.Controls.Add(Drinks, 0, 9);
            Drinks.SelectedIndexChanged += ComboboxChanged;
            Drinks.Click += DrinksClick;


            CustomerDiscountCode = new TextBox
            {
                Text = "Skriv in ev. rabattkod här",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Bottom
            };
            Table.Controls.Add(CustomerDiscountCode, 0, 10);
            CustomerDiscountCode.MaxLength = 6;
            CustomerDiscountCode.Click += DiscountCodeEmtyOnClick;


            Button DiscountCodeCheck = new Button
            {
                Text = "OK",
                Font = new Font("Times New Roman", 12),
                BackColor = Color.Honeydew,
                AutoSize = true,
                Width = (int)Text.Length,
                Dock = DockStyle.None
            };
            Table.Controls.Add(DiscountCodeCheck, 0, 11);
            DiscountCodeCheck.Click += DiscountCodeCheckClick;
            CustomerDiscountCode.KeyPress += CustomerDiscountCodeEnter;


            // Slumpar fram restaurang-bilderna och lägger i PictureBox
            RndPicture = new Random().Next(1, 8);
            Picture = new PictureBox
            {
                Image = Image.FromFile(@".\restPictures\" + "pic" + RndPicture + ".jpg"),
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
                Font = new Font("Times New Roman", 14),
                BackColor = Color.Honeydew
            };
            Table.Controls.Add(add, 1, 9);
            add.Click += AddClick;


            Button remove = new Button
            {
                Text = "Ta bort",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                BackColor = Color.AntiqueWhite
            };
            Table.Controls.Add(remove, 1, 10);
            remove.Click += RemoveClick;


            Button clearChart = new Button
            {
                Text = "Rensa hela beställningen",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                BackColor = Color.AntiqueWhite
            };
            Table.Controls.Add(clearChart, 1, 11);
            clearChart.Click += ClearChartClick;


            Label orderLabel = new Label
            {
                Text = "Beställning",
                Font = new Font("Times New Roman", 18),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Table.Controls.Add(orderLabel, 2, 1);


            OrderList = new DataGridView
            {
                ColumnCount = 3,
                RowHeadersVisible = false,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.WhiteSmoke,
                Font = new Font("Times New Roman", 12),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            };
            Table.Controls.Add(OrderList, 2, 2);
            Table.SetRowSpan(OrderList, 7);
            OrderList.Columns[0].FillWeight = 16;
            OrderList.Columns[1].FillWeight = 64;
            OrderList.Columns[2].FillWeight = 20;
            OrderList.Columns[0].Name = "Antal";
            OrderList.Columns[1].Name = "Maträtt";
            OrderList.Columns[2].Name = "Pris/st";
            OrderList.Columns["Antal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            OrderList.Columns["Pris/st"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            OrderList.CellClick += OrderListClick;


            TotalPriceLabel = new Label
            {
                Text = "Pris totalt:",
                Font = new Font("Times New Roman", 14),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
            Table.Controls.Add(TotalPriceLabel, 2, 9);


            Button order = new Button
            {
                Text = "Beställ",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                BackColor = Color.Honeydew
            };
            Table.Controls.Add(order, 2, 10);
            order.Click += OrderClick;


            Button saveOrder = new Button
            {
                Text = "Spara beställningen",
                Font = new Font("Times New Roman", 14),
                Dock = DockStyle.Fill,
                BackColor = Color.Honeydew
            };
            Table.Controls.Add(saveOrder, 2, 11);
            saveOrder.Click += SaveOrderClick;


            ListStarters = new List<Product>();
            ListWarmDishes = new List<Product>();
            ListDesserts = new List<Product>();
            ListDrinks = new List<Product>();


            // Splittar produkterna och lägger i 4 olika listor.
            ProductArray = File.ReadAllLines("products.csv");
            foreach (string line in ProductArray)
            {
                string[] parts = line.Split(';');
                // Kollar om fel i produktlistan.
                try
                {
                    string index = parts[0];
                    int price = int.Parse(parts[1]);
                    string name = parts[2];
                    string description = parts[3];

                    if (index.StartsWith("s"))
                    {
                        ListStarters.Add(new Product
                        {
                            Price = price,
                            Name = name,
                            Description = description
                        });
                    }
                    else if (index.StartsWith("w"))
                    {
                        ListWarmDishes.Add(new Product
                        {
                            Price = price,
                            Name = name,
                            Description = description
                        });
                    }
                    else if (index.StartsWith("d"))
                    {
                        ListDesserts.Add(new Product
                        {
                            Price = price,
                            Name = name,
                            Description = description
                        });
                    }
                    else if (index.StartsWith("f"))
                    {
                        ListDrinks.Add(new Product
                        {
                            Price = price,
                            Name = name,
                            Description = description
                        });
                    }
                }
                catch
                {
                    MessageBox.Show("Fel i produktlistan! Produkterna kommer att visas fel i menyn.");
                }
            }


            // Lägger till produkterna i dropdowlistorna.
            foreach (Product p in ListStarters)
            {
                Starters.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in ListWarmDishes)
            {
                WarmDishes.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in ListDesserts)
            {
                Desserts.Items.Add(p.Name + " - " + p.Price + " kr");
            };
            foreach (Product p in ListDrinks)
            {
                Drinks.Items.Add(p.Name + " - " + p.Price + " kr");
            }


            // Läser in sparad varukorg till TotalOrderDictionary.
            TotalPrice = 0;
            TotalPriceWithDiscount = 0;
            TotalOrderDictionary = new Dictionary<string, int>();
            string[] cartLines = File.ReadAllLines(@"C:\Temp\Cart.csv");
            // Kontrollerar om det finns en sparad varukorg.
            if (cartLines.Length != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Det finns en sparad varukorg. Vill du öppna den? ", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string cartLine in cartLines)
                    {
                        CartArray = cartLine.Split(';');
                        // Adderar priset för varje objekt i kundvagnen till TotalPrice.
                        foreach (Product p in ListStarters)
                        {
                            AddToTotalPrice(p);
                        }
                        foreach (Product p in ListWarmDishes)
                        {
                            AddToTotalPrice(p);
                        }
                        foreach (Product p in ListDesserts)
                        {
                            AddToTotalPrice(p);
                        }
                        foreach (Product p in ListDrinks)
                        {
                            AddToTotalPrice(p);
                        }
                    }
                    File.Create(@"C:\Temp\Cart.csv").Dispose();
                }
                TotalPriceLabel.Text = "Pris totalt:  " + TotalPrice + " kr";
            }
            // Lägger till antal, namn och pris, från sparade varukorgen, till DataGridView.
            foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
            {
                string orderNy = pair.Key;
                OrderArray = orderNy.Split(new char[] { '-' });
                OrderList.Rows.Add(pair.Value, OrderArray[0], OrderArray[1]);
            }
        }

        // Metod som adderar priset för varje objekt i kundvagnen till TotalPrice.
        private void AddToTotalPrice(Product p)
        {
            if (CartArray[0] == (p.Name + " - " + p.Price + " kr"))
            {
                TotalPrice += p.Price * int.Parse(CartArray[1]);
                TotalOrderDictionary[p.Name + " - " + p.Price + " kr"] = int.Parse(CartArray[1]);
            }
        }


        // Raderar texten i drop-down listorna för alla utom den markerade.
        private void StartersClick(object sender, EventArgs e)
        {
            WarmDishes.SelectedIndex = -1;
            Desserts.SelectedIndex = -1;
            Drinks.SelectedIndex = -1;
        }
        private void WarmDishesClick(object sender, EventArgs e)
        {
            Starters.SelectedIndex = -1;
            Desserts.SelectedIndex = -1;
            Drinks.SelectedIndex = -1;
        }
        private void DessertsClick(object sender, EventArgs e)
        {
            Starters.SelectedIndex = -1;
            WarmDishes.SelectedIndex = -1;
            Drinks.SelectedIndex = -1;
        }
        private void DrinksClick(object sender, EventArgs e)
        {
            Starters.SelectedIndex = -1;
            WarmDishes.SelectedIndex = -1;
            Desserts.SelectedIndex = -1;
        }


        // Raderar texten i Textbox för rabattkoder om man klickar på Textboxen.
        private void DiscountCodeEmtyOnClick(object sender, EventArgs e)
        {
            CustomerDiscountCode.Clear();
        }


        // Kontrollerar rabattkoden vid tryck på "enter".
        private void CustomerDiscountCodeEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                DiscountCheck();
            }
            CustomerDiscountCode.SelectionLength = 6;
        }


        // Kontrollerar rabattkoden vid tryck på OK knappen. 
        private void DiscountCodeCheckClick(object sender, EventArgs e)
        {
            DiscountCheck();
        }


        // Metod som Kontrollerar om rabattkoden stämmer och räknar i så fall ut rabatten.
        private void DiscountCheck()
        {
            string[] discountCodes = File.ReadAllLines("rabattkoder.csv");
            if (CustomerDiscountCode.Text != "")
            {
                int counter = 0;
                foreach (string line in discountCodes)
                {
                    string[] voucherCodePercentage = line.Split(',');
                    Percentage = int.Parse(voucherCodePercentage[1]);

                    if (CustomerDiscountCode.Text == voucherCodePercentage[0])
                    {
                        MessageBox.Show("Du har angett en rabattkod som ger " + Percentage + "% rabatt");
                        counter = 1;
                        if(TotalPrice != 0)
                        {
                            TotalPriceWithDiscount = TotalPrice - (TotalPrice * Percentage / 100);
                            TotalPriceLabel.Text = "Pris totalt:         " + TotalPrice + " kr" + "\n" + "Pris inkl rabatt:  " + TotalPriceWithDiscount + " kr";
                        }
                        break;
                    }
                }
                if (counter == 0)
                {
                    MessageBox.Show("Du har angett en ogiltig rabattkod!");
                    CustomerDiscountCode.Clear();
                }
            }
        }


        // Lägger till bild i PictureBox och beskrivning i DescriptionBox när man väljer från dropdown-listorna.
        private void ComboboxChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            ComboBoxClickItem = Convert.ToString(c.SelectedItem);

            // Lägger till rätt bild i PictureBox.
            string indexProducts = "";
            if (c.SelectedIndex != -1)
            {
                if (sender == Starters)
                {
                    indexProducts = "s";
                }
                else if (sender == WarmDishes)
                {
                    indexProducts = "w";
                }
                else if (sender == Desserts)
                {
                    indexProducts = "d";
                }
                else
                {
                    indexProducts = "f";
                }
                Picture.Image = Image.FromFile(@".\pictures\" + indexProducts + (c.SelectedIndex + 1) + ".jpg");
            }

            // Lägger till rätt beskrivning i DescriptionBox.
            foreach (string line in ProductArray)
            {
                string[] parts = line.Split(';');
                // Kontrollerar om alla 4 egenskaper (index, pris, produkt och beskrivning) finns med i varje produkt
                if (parts.Length == 4)
                {
                    string index = parts[0];
                    string description = parts[3];

                    if (index == indexProducts + (c.SelectedIndex + 1))
                    {
                        DescriptionBox.Text = description;
                    }
                }
            }
        }


        // Lägger till beställningen till TotalOrderDictinary och TotalPrice samt presenterar den i DataGridView.
        private void AddClick(object sender, EventArgs e)
        {
            if (ComboBoxClickItem != null)
            {
                // Lägger till beställningen till TotalOrderDictionary.
                if (TotalOrderDictionary.ContainsKey(ComboBoxClickItem))
                {
                    TotalOrderDictionary[ComboBoxClickItem] += 1;
                }
                else
                {
                    TotalOrderDictionary[ComboBoxClickItem] = 1;
                }

                // Lägger till priset i TotalPrice samt visar i "Pris totalt"-rutan.
                string[] OrderArray = ComboBoxClickItem.Split(new char[] { '-' });
                int price = int.Parse(OrderArray[1].Replace(" kr", string.Empty));
                TotalPrice += price;
                if(Percentage == 0)
                {
                    TotalPriceLabel.Text = "Pris totalt:  " + TotalPrice + " kr";
                }
                else
                {
                    TotalPriceWithDiscount = TotalPrice - (TotalPrice * Percentage / 100);
                    TotalPriceLabel.Text = "Pris totalt:         " + TotalPrice + " kr" + "\n" + "Pris inkl rabatt:  " + TotalPriceWithDiscount + " kr";

                }

                // Lägger till antal, namn och pris till DataGridView.
                OrderList.Rows.Clear();
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    OrderArray = pair.Key.Split(new char[] { '-' });
                    OrderList.Rows.Add(pair.Value, OrderArray[0], OrderArray[1]);
                }
                OrderList.CurrentCell.Selected = false;
            }
            else
            {
                MessageBox.Show("Du måste välja en rätt under \"Meny\"!");
            }
        }


        // Hämtar namnet och priset på maträtten från DataGridView.
        private void OrderListClick(object sender, EventArgs e)
        {
            string orderName = OrderList.CurrentRow.Cells[1].Value.ToString();
            OrderPrice = OrderList.CurrentRow.Cells[2].Value.ToString();
            OrderNameAndPrice = orderName + "-" + OrderPrice;
        }


        // Tar bort beställningen från TotalOrderDictionary och TotalPrice samt presenterar den i DataGridView.
        private void RemoveClick(object sender, EventArgs e)
        {
            if (TotalOrderDictionary.Count > 0)
            {
                if (OrderNameAndPrice != null)
                {
                    string productInGrid = Convert.ToString(OrderList.Rows[0].Cells["Maträtt"].Value);
                    string priceInGrid = Convert.ToString(OrderList.Rows[0].Cells["Pris/st"].Value);
                    string productPriceInGrid = productInGrid + "-" + priceInGrid;

                    if (TotalOrderDictionary.ContainsKey(OrderNameAndPrice))
                    {
                        TotalOrderDictionary[OrderNameAndPrice] -= 1;

                        // Subtraherar priset från "Pris totalt"-rutan.
                        int price = int.Parse(OrderPrice.Replace(" kr", string.Empty));
                        TotalPrice -= price;
                        if (TotalPriceWithDiscount == 0)
                        {
                            TotalPriceLabel.Text = "Pris totalt:  " + TotalPrice + " kr";
                        }
                        else
                        {
                            TotalPriceWithDiscount = TotalPrice - (TotalPrice * Percentage / 100);
                            TotalPriceLabel.Text = "Pris totalt:         " + TotalPrice + " kr" + "\n" + "Pris inkl rabatt:  " + TotalPriceWithDiscount + " kr";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Markera under \"Beställning\" den vara du vill ta bort!");
                    OrderList.CurrentCell.Selected = false; // Tar bort automatiska cellmarkeringen i DatGridView
                }                

                // Om antalet av en beställning blir 0 så tas den bort i TotalOrderDictioanry.
                foreach (var item in TotalOrderDictionary.Where(KeyValuePair => KeyValuePair.Value == 0).ToList())
                {
                    TotalOrderDictionary.Remove(item.Key);
                    OrderNameAndPrice = null;
                }

                // Lägger till antal, namn och pris till DataGridView.
                OrderList.Rows.Clear();
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    OrderArray = pair.Key.Split(new char[] { '-' });
                    OrderList.Rows.Add(pair.Value, OrderArray[0], OrderArray[1]);
                }
                
                // Om TotalOrderDictionary inte är tom tas den automatiska cellmarkeringen bort i DataGrid View.
                if (TotalOrderDictionary.Count != 0)
                {
                    OrderList.CurrentCell.Selected = false;
                }                
            }
            else
            {
                MessageBox.Show("Det finns inget i beställningen att ta bort!");
            }
        }


        // Rensar hela beställningen vid tryck på den knappen.
        private void ClearChartClick(object sender, EventArgs e)
        {
            ClearAll();
        }


        // Gör iordning och presenterar kvittot.
        private void OrderClick(object sender, EventArgs e)
        {
            if(TotalOrderDictionary.Count != 0)
            {
                string receipt = "";
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    receipt += pair.Value + " st. " + pair.Key + "\n";
                }
                string priceInfo = TotalPrice + " SEK";

                // Kontrollerar om rabattkoden stämmer och räknar i så fall ut rabatten.            
                string[] discountCodes = File.ReadAllLines("rabattkoder.csv");
                if (CustomerDiscountCode.Text != "" && CustomerDiscountCode.Text != "Skriv in ev. rabattkod här" || Percentage != 0)
                {
                    if (Percentage == 0)
                    {
                        int counter = 0;
                        foreach (string line in discountCodes)
                        {
                            string[] voucherCodePercentage = line.Split(',');
                            Percentage = int.Parse(voucherCodePercentage[1]);

                            if (CustomerDiscountCode.Text == voucherCodePercentage[0])
                            {
                                MessageBox.Show("Du har angett en rabattkod som ger " + Percentage + "% rabatt");
                                counter = 1;
                                if (TotalPrice != 0)
                                {
                                    TotalPriceWithDiscount = TotalPrice - (TotalPrice * Percentage / 100);
                                    TotalPriceLabel.Text = "Pris totalt:         " + TotalPrice + " kr" + "\n" + "Pris inkl rabatt:  " + TotalPriceWithDiscount + " kr";
                                    priceInfo = TotalPriceWithDiscount + " SEK" + "\n" + "(Din rabatt " + (TotalPrice * Percentage / 100) + " SEK)";

                                }
                                break;
                            }
                        }
                        CustomerDiscountCode.Clear();
                        if (counter == 0)
                        {
                            MessageBox.Show("Du har angett en ogiltig rabattkod!");
                            CustomerDiscountCode.Clear();
                        }
                    }
                    else
                    {
                        TotalPriceWithDiscount = TotalPrice - (TotalPrice * Percentage / 100);
                        priceInfo = TotalPriceWithDiscount + " SEK" + "\n" + "(Din rabatt " + (TotalPrice * Percentage / 100) + " SEK)";
                    }
                }
                Picture.Image = Image.FromFile(@".\restPictures\pic8.jpg");

                // Kvittot presenteras.
                MessageBox.Show(
                    "*** RESTAURANG SEA SHARP ***" + "\n" +
                    "----------------------------" + "\n" +
                    DateTime.Now + "\n" +
                    "----------------------------" + "\n" +
                    receipt + "\n" +
                    "**************************" + "\n" +
                    "ATT BETALA: " + priceInfo + "\n\n" +
                    "Välkommen åter!"
                    );
                ClearAll();                
            }
            else
            {
                MessageBox.Show("Du har inte gjort någon beställning ännu!");
            }
        }


        // Sparar beställningen i en fil.
        private void SaveOrderClick(object sender, EventArgs e)
        {
            if(TotalOrderDictionary.Count != 0)
            {
                string csvFile = string.Join(Environment.NewLine, TotalOrderDictionary.Select(d => d.Key + ";" + d.Value));
                System.IO.File.WriteAllText(@"C:\Temp\Cart.csv", csvFile);
                Picture.Image = Image.FromFile(@".\restPictures\pic8.jpg");
                MessageBox.Show("Din varukorg är sparad!");
                ClearAll();
            }
            else
            {
                MessageBox.Show("Det finns ingen varukorg att spara!");
            }
        }


        // Rensar beställningen och återställer skärmen. 
        private void ClearAll()
        {
            OrderList.Rows.Clear();
            TotalOrderDictionary.Clear();
            TotalPrice = 0;
            TotalPriceWithDiscount = 0;
            Percentage = 0;
            TotalPriceLabel.Text = "Pris totalt:  ";
            Picture.Image = Image.FromFile(@".\restPictures\" + "pic" + RndPicture + ".jpg");
            DescriptionBox.Clear();
            CustomerDiscountCode.Text = "Skriv in ev. rabattkod här";
            Starters.SelectedIndex = -1;
            WarmDishes.SelectedIndex = -1;
            Desserts.SelectedIndex = -1;
            Drinks.SelectedIndex = -1;
            ComboBoxClickItem = null;
            OrderNameAndPrice = null;
        }
    }
}