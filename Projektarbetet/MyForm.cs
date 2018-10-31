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
            //public string Index;
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
        public string ComboBoxClickItem;
        public Dictionary<string, int> TotalOrderDictionary;
        public int TotalPrice;
        public Label TotalPriceLabel;
        public string OrderNamePrice;
        public string OrderPrice;
        public string[] OrderArray;
        public int DataGridViewRowIndex;
        public int DataGridViewColumnIndex;
        public string OrderString;
        public TextBox CustomerDiscountCode;
        public int rndPicture;

        public MyForm()
        {
            // Anger storleken på fönstret.
            WindowState = FormWindowState.Maximized;


            TableLayoutPanel Table = new TableLayoutPanel
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
            rndPicture = new Random().Next(1, 4);
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
                Text = "Rensa beställningen",
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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
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


            List<Product> listStarters = new List<Product>();
            List<Product> listWarmDishes = new List<Product>();
            List<Product> listDesserts = new List<Product>();
            List<Product> listDrinks = new List<Product>();



            // Splittar produkterna och lägger i 4 olika listor.
            string[] lines = File.ReadAllLines("products.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                try     // Kollar om fel i produktlistan.
                {
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
                catch
                {
                    MessageBox.Show("Fel i produktlistan");
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


            // Läser in sparad varukorg till TotalOrderDictionary.
            TotalPrice = 0;
            TotalOrderDictionary = new Dictionary<string, int>();   // Skapar en tom dictionary för att spara varukorgen i.
            string[] cartLines = File.ReadAllLines(@"C:\Temp\Cart.csv"); // Läser in kundvagnen i en array sträng.
            if (cartLines.Length != 0)
            {
                // Kontrollerar om det finns en sparad varukorg.
                DialogResult dialogResult = MessageBox.Show("Det finns en sparad varukorg. Vill du öppna den? ", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string cartLine in cartLines)
                    {
                        string[] cartValues = cartLine.Split(',');  //splittar varje rad i kundvagnen vid kommatecknen i en ny array cartValues

                        foreach (Product p in listStarters) // Lägger till priset för varje objekt i kundvagnen till totalSum.
                        {
                            if (cartValues[0] == (p.Name + " - " + p.Price + " kr"))
                            {
                                int currentPrice = p.Price * int.Parse(cartValues[1]);
                                TotalPrice += currentPrice;
                                TotalOrderDictionary[p.Name + " - " + p.Price + " kr"] = int.Parse(cartValues[1]);
                            }
                        }
                        foreach (Product p in listWarmDishes) // Lägger till priset för varje objekt i kundvagnen till totalSum.
                        {
                            if (cartValues[0] == (p.Name + " - " + p.Price + " kr"))
                            {
                                int currentPrice = p.Price * int.Parse(cartValues[1]);
                                TotalPrice += currentPrice;
                                TotalOrderDictionary[p.Name + " - " + p.Price + " kr"] = int.Parse(cartValues[1]);
                            }
                        }
                        foreach (Product p in listDesserts) // Lägger till priset för varje objekt i kundvagnen till TotalPrice.
                        {
                            if (cartValues[0] == (p.Name + " - " + p.Price + " kr"))
                            {
                                int currentPrice = p.Price * int.Parse(cartValues[1]);
                                TotalPrice += currentPrice;
                                TotalOrderDictionary[p.Name + " - " + p.Price + " kr"] = int.Parse(cartValues[1]);
                            }
                        }
                        foreach (Product p in listDrinks) // Lägger till priset för varje objekt i kundvagnen till TotalPrice.
                        {
                            if (cartValues[0] == (p.Name + " - " + p.Price + " kr"))
                            {
                                int currentPrice = p.Price * int.Parse(cartValues[1]);
                                TotalPrice += currentPrice;
                                TotalOrderDictionary[p.Name + " - " + p.Price + " kr"] = int.Parse(cartValues[1]);
                            }
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    File.Create(@"C:\Temp\Cart.csv").Dispose();
                }
            }



            // Lägger till priset i "Pris totalt"-rutan.            
            TotalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";


            // Lägger till antal, namn och pris, från sparade varukorgen, till DataGridView.
            foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
            {
                string orderNy = pair.Key;
                OrderArray = orderNy.Split(new char[] { '-' });
                OrderList.Rows.Add(pair.Value, OrderArray[0], OrderArray[1]);
            }
            //OrderList.CurrentCell.Selected = false; // Tar bort automatiska cellmarkeringen i DatGridView.
        }


        // Raderar texten i drop-down listorna för alla utom den markerade
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



        // Raderar texten i Textbox för rabattkoder om man klickar på Textboxen
        private void DiscountCodeEmtyOnClick(object sender, EventArgs e)
        {
            CustomerDiscountCode.Clear();
        }



        // Kontrollerar vid tryck på enter om rabattkoden stämmer och räknar i så fall ut rabatten.
        private void CustomerDiscountCodeEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string[] discountCodes = File.ReadAllLines("rabattkoder.csv");

                if (CustomerDiscountCode.Text != "")
                {
                    int Counter = 0;
                    foreach (string line in discountCodes)
                    {
                        string[] voucherCodePercentage = line.Split(',');
                        int percentage = int.Parse(voucherCodePercentage[1]);

                        if (CustomerDiscountCode.Text == voucherCodePercentage[0])
                        {
                            MessageBox.Show("Du har angett en rabattkod som ger " + percentage + "% rabatt");
                            Counter = 1;
                        }
                    }
                    if (Counter == 0)
                    {
                        MessageBox.Show("Du har angett en ogiltig rabattkod!");
                        CustomerDiscountCode.Clear();
                    }
                }
            }
        }



        // Kontrollerar vid tryck på OK knappen om rabattkoden stämmer och räknar i så fall ut rabatten. 
        private void DiscountCodeCheckClick(object sender, EventArgs e)
        {
            string[] discountCodes = File.ReadAllLines("rabattkoder.csv");

            if (CustomerDiscountCode.Text != "")
            {
                int Counter = 0;
                foreach (string line in discountCodes)
                {
                    string[] voucherCodePercentage = line.Split(',');
                    int percentage = int.Parse(voucherCodePercentage[1]);

                    if (CustomerDiscountCode.Text == voucherCodePercentage[0])
                    {
                        MessageBox.Show("Du har angett en rabattkod som ger " + percentage + "% rabatt");
                        Counter = 1;
                    }
                }
                if (Counter == 0)
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
            ComboBoxClickItem = Convert.ToString(c.SelectedItem);   // Vald rätt sparas i ComboBoxClickItem

            // Lägger till rätt bild i PictureBox.
            string index1 = "";
            if (c.SelectedIndex != -1)
            {
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
            }

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
                string[] OrderArray = ComboBoxClickItem.Split(new char[] { '-' });
                int price = int.Parse(OrderArray[1].Replace(" kr", string.Empty));  //System.IndexOutOfRangeException: 'Indexet låg utanför gränserna för matrisen.'
                TotalPrice += price;
                TotalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";


                OrderList.Rows.Clear();
                // Lägger till antal, namn och pris till DataGridView.
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    string order = pair.Key;
                    OrderArray = order.Split(new char[] { '-' });
                    OrderList.Rows.Add(pair.Value, OrderArray[0], OrderArray[1]);
                }
                OrderList.CurrentCell.Selected = false; // Tar bort automatiska cellmarkeringen i DatGridView
            }
        }



        // Hämtar namnet och priset på maträtten från DataGridView.
        private void OrderListClick(object sender, EventArgs e)
        {
            DataGridViewRowIndex = OrderList.CurrentRow.Index; // Ger index på raden som markerats
            DataGridViewColumnIndex = OrderList.CurrentCell.ColumnIndex;    // Ger index på columnen som markerats
            string orderName = OrderList.CurrentRow.Cells[1].Value.ToString();
            OrderPrice = OrderList.CurrentRow.Cells[2].Value.ToString();
            OrderNamePrice = orderName + "-" + OrderPrice;
        }



        // Tar bort beställningen från DataGridView.
        private void RemoveClick(object sender, EventArgs e)
        {
            if (TotalOrderDictionary.Count > 0) // Kollar om det finns något i TotalOrderDictionary.
            {
                if (OrderNamePrice != null) // Kollar att OrderNamePrice inte är null.
                {
                    string productInGrid = Convert.ToString(OrderList.Rows[0].Cells["Maträtt"].Value);
                    string priceInGrid = Convert.ToString(OrderList.Rows[0].Cells["Pris/st"].Value);
                    string productPriceInGrid = productInGrid + "-" + priceInGrid;

                    if (TotalOrderDictionary.ContainsKey(OrderNamePrice))
                    {
                        TotalOrderDictionary[OrderNamePrice] -= 1;

                        // Subtraherar priset från "Pris totalt"-rutan.
                        int price = int.Parse(OrderPrice.Replace(" kr", string.Empty));
                        TotalPrice -= price;
                        TotalPriceLabel.Text = "Pris totalt:  " + Convert.ToString(TotalPrice) + " kr";
                    }
                }
                else
                {
                    MessageBox.Show("Markera den vara du vill ta bort!");
                }

                // Om antalet av en beställning blir 0 så tas den bort.
                foreach (var item in TotalOrderDictionary.Where(KeyValuePair => KeyValuePair.Value == 0).ToList())
                {
                    TotalOrderDictionary.Remove(item.Key);
                    OrderNamePrice = null;
                }

                // Lägger till antal, namn och pris till DataGridView.
                OrderList.Rows.Clear();
                foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
                {
                    OrderString = pair.Key;
                    OrderArray = OrderString.Split(new char[] { '-' });
                    OrderList.Rows.Add(pair.Value, OrderArray[0], OrderArray[1]);
                }

                //Här skall koden in som avmarkerar cellen
                //orderList.Rows[DataGridViewRowIndex].Cells[DataGridViewColumnIndex].Selected = false;


                // Om TotalOrderDictionary inte är tom tas den automatiska cellmarkeringen bort i DataGrid View
                if (TotalOrderDictionary.Count != 0)
                {
                    OrderList.CurrentCell.Selected = false; // Tar bort cellmarkeringen i DatGridView.
                }

                // Sparar markeringen i cellen om inte raden i DataGridView tagits bort
                if (DataGridViewRowIndex < TotalOrderDictionary.Count)
                {
                    OrderList.CurrentCell.Selected = false; // Ta ej bort denna!! Tar bort automatiska cellmarkeringen i DatGridView
                    OrderList.Rows[DataGridViewRowIndex].Cells[DataGridViewColumnIndex].Selected = true;
                }
            }
        }



        // Rensar hela beställningen.
        private void ClearChartClick(object sender, EventArgs e)
        {
            OrderList.Rows.Clear();
            TotalOrderDictionary.Clear();
            TotalPrice = 0;
            TotalPriceLabel.Text = "Pris totalt:  ";
            OrderNamePrice = null;
        }



        // Gör iordning och presenterar kvittot.
        private void OrderClick(object sender, EventArgs e)
        {
            string receipt = "";
            foreach (KeyValuePair<string, int> pair in TotalOrderDictionary)
            {
                receipt += pair.Value + " st. " + pair.Key + "\n";
            }

            string priceInfo = TotalPrice + " SEK";
            string[] discountCodes = File.ReadAllLines("rabattkoder.csv");


            if (CustomerDiscountCode.Text != "")
            {
                // Kontrollerar om rabattkoden stämmer och räknar i så fall ut rabatten.
                foreach (string line in discountCodes)
                {
                    string[] voucherCodePercentage = line.Split(',');
                    int percentage = int.Parse(voucherCodePercentage[1]);

                    if (CustomerDiscountCode.Text == voucherCodePercentage[0])
                    {
                        priceInfo = (TotalPrice - (TotalPrice * percentage) / 100) + " SEK" + "\n" +
                                   "(Din rabatt " + ((TotalPrice * percentage) / 100) + " SEK)";
                    }
                }
            }

            // Kvittot presenteras.
            Font = new Font("Times New Roman", 18);
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

            // Rensar beställningen och återställer skärmen.
            OrderList.Rows.Clear();
            TotalOrderDictionary.Clear();
            TotalPrice = 0;
            TotalPriceLabel.Text = "Pris totalt:  ";
            Picture.Image = Image.FromFile("pic" + rndPicture + ".jpg");
            DescriptionBox.Clear();
            CustomerDiscountCode.Text = "Skriv in ev. rabattkod här";
            Starters.SelectedIndex = -1;
            WarmDishes.SelectedIndex = -1;
            Desserts.SelectedIndex = -1;
            Drinks.SelectedIndex = -1;
            ComboBoxClickItem = null;
            OrderNamePrice = null;
            File.Create(@"C:\Temp\Cart.csv").Dispose();
        }



        // Sparar beställningen i en fil.
        private void SaveOrderClick(object sender, EventArgs e)
        {
            string csvFile = string.Join(Environment.NewLine, TotalOrderDictionary.Select(d => d.Key + "," + d.Value));
            System.IO.File.WriteAllText(@"C:\Temp\Cart.csv", csvFile);
            MessageBox.Show("Din varukorg är sparad!");

            // Rensar beställningen och återställer skärmen.            
            OrderList.Rows.Clear();
            TotalOrderDictionary.Clear();
            TotalPrice = 0;
            TotalPriceLabel.Text = "Pris totalt:  ";
            Picture.Image = Image.FromFile("pic" + rndPicture + ".jpg");
            DescriptionBox.Clear();
            CustomerDiscountCode.Text = "Skriv in ev. rabattkod här";
            Starters.SelectedIndex = -1;
            WarmDishes.SelectedIndex = -1;
            Desserts.SelectedIndex = -1;
            Drinks.SelectedIndex = -1;
            ComboBoxClickItem = null;
            OrderNamePrice = null;
        }
    }
}
