using System.Drawing.Imaging;
using System.Text.Json;

namespace AlienDecryptor {

    public partial class MainForm : Form {

        private static readonly string INPUT_IMAGE = "Data\\c7c3464709754810b3efcaa6704fed61_hoch_flipped.png";
        private static readonly string STORAGE_FILE = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\AlienDecryptor\\data.json";

        private static readonly Size SIZE_SYMBOL = new Size(22, 38);
        private static readonly int XOFFSET = 18; // 30
        private static readonly int XSPACE = 10;

        private List<Symbol> symbols = new List<Symbol>();
        private List<Letter> text = new List<Letter>();

        private Bitmap bitmapAlien = new Bitmap(1, 1);
        private Bitmap bitmapTranslation = new Bitmap(1, 1);

        public MainForm() {
            InitializeComponent();

            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowTemplate.Height = 39;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadSymbols();

            ParseAlienText();

            SaveSymbols();

            CreateTranslation();

            LoadGrid();
        }

        private void CreateTranslation() {
            bitmapTranslation = (Bitmap)bitmapAlien.Clone();

            using (Graphics gfx = Graphics.FromImage(bitmapTranslation)) {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(240, 240, 240))) {
                    gfx.FillRectangle(brush, 0, 0, bitmapTranslation.Width, bitmapTranslation.Height);
                }

                foreach (Letter letter in text) {
                    var bms = letter.Symbol.BitmapDest;
                    gfx.DrawImage(bms, new Rectangle(letter.Position.X, letter.Position.Y, bms.Width, bms.Height), new Rectangle(0, 0, bms.Width, bms.Height), GraphicsUnit.Pixel);
                }
            }

            pictureBox.Image = bitmapTranslation;
        }

        private void ParseAlienText() {
            foreach (var symbol in symbols) {
                symbol.Count = 0;
            }

            bitmapAlien = new Bitmap(INPUT_IMAGE);

            Size size = bitmapAlien.Size;
            Rectangle dsection = new Rectangle(new Point(0, 0), SIZE_SYMBOL);

            int row = 1;
            for (int y = 0; y < size.Height && row <= 5000; y++) {
                for (int x = 0; x < size.Width; x++) {
                    var color = bitmapAlien.GetPixel(x, y);
                    var val = color.R;
                    if (val == 0) {
                        int y1 = y - 1;
                        int col = 1;
                        for (int x1 = XOFFSET; x1 < (size.Width - SIZE_SYMBOL.Width + 1); x1 += SIZE_SYMBOL.Width + XSPACE) {
                            var section = new Rectangle(new Point(x1, y1), SIZE_SYMBOL);
                            var bitmapSymbol = new Bitmap(section.Width, section.Height, PixelFormat.Format24bppRgb);
                            using (Graphics g = Graphics.FromImage(bitmapSymbol)) {
                                g.DrawImage(bitmapAlien, dsection, section, GraphicsUnit.Pixel);
                            }

                            Symbol symbol = new(bitmapSymbol);

                            Symbol? other = symbols.Where(s => s.Equals(symbol)).FirstOrDefault();
                            if (other != null) {
                                symbol = other;
                                other.Count++;
                            } else {
                                symbols.Add(symbol);
                            }

                            text.Add(new Letter(symbol, new Point(x1, y1)));

                            // dataGridView.Rows.Add(0, bmp, 0, $"{row}, {col}");

                            col++;
                        }
                        row++;
                        y = y1 + SIZE_SYMBOL.Height + 9;

                        break;
                    }
                }
            }

            symbols.RemoveAll(s => s.Count == 0);
        }

        private void LoadGrid() {
            symbols.Sort((s1, s2) => -s1.Count.CompareTo(s2.Count));

            dataGridView.Rows.Clear();

            int sidx = 1;
            foreach (var symbol in symbols) {
                symbol.Index = sidx++;
                var gvIndex = dataGridView.Rows.Add(symbol.Index, symbol.BitmapSource, symbol.Count, symbol.BitmapDest, symbol.Letter < 32 ? " " : symbol.Letter);
                dataGridView.Rows[gvIndex].Tag = symbol;
            }

            dataGridView.CurrentCell = dataGridView.Rows[0].Cells[0];
        }

        private void SaveSymbols() {
            if (File.Exists(STORAGE_FILE)) {
                // var date = File.GetLastWriteTime(STORAGE_FILE);
                // File.Copy(STORAGE_FILE, STORAGE_FILE + $".{date:yyyy-MM-dd_hh_mm_ss}.bak", true);
            }
            var dir = Path.GetDirectoryName(STORAGE_FILE);
            if (dir != null && !Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            using (StreamWriter writer = new StreamWriter(STORAGE_FILE)) {
                var jsonString = JsonSerializer.Serialize(symbols);
                writer.WriteLine(jsonString);
            }
        }

        private void LoadSymbols() {
            if (File.Exists(STORAGE_FILE)) {
                using (StreamReader r = new StreamReader(STORAGE_FILE)) {
                    string json = r.ReadToEnd();
                    var symbols2 = JsonSerializer.Deserialize(json, symbols.GetType()) as List<Symbol>;
                    if (symbols2 == null) {
                        throw new Exception("Deserialization failed");
                    }
                    symbols = symbols2;
                }
                LoadGrid();
            }
        }

        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e) {
            char letter = e.KeyChar;
            if (dataGridView.CurrentCell != null) {
                int idx = dataGridView.CurrentCell.RowIndex;
                var row = dataGridView.Rows[idx];
                Symbol? symbol = row.Tag as Symbol;
                if (symbol != null) {
                    symbol.Letter = letter;
                    row.Cells["Translate"].Value = symbol.BitmapDest;
                    row.Cells["Letter"].Value = symbol.Letter < 32 ? " " : symbol.Letter;
                    SaveSymbols();
                    CreateTranslation();
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            pictureBox.Image = bitmapAlien;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
            pictureBox.Image = bitmapTranslation;
        }

        private void hilfeAnzeigenToolStripMenuItem_Click(object sender, EventArgs e) {
            (new HelpForm()).Show();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }
}