using System.Collections;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace AlienDecryptor {

    public class Symbol {

        private static readonly Font FONT = new Font("Courier New", 22, FontStyle.Bold);
        private static readonly Brush BRUSH = Brushes.ForestGreen;

        [JsonConverter(typeof(BitmapConverter))]
        public Bitmap BitmapSource { get; private set; }

        [JsonIgnore]
        public Bitmap BitmapDest { get; private set; }

        public int Count { get; set; } = 1;

        public int Index { get; set; }

        private char _letter = '\0';
        public char Letter {
            get => _letter;
            set {
                _letter = value;
                if (_letter >= 'a' && _letter <= 'z') {
                    _letter = char.ToUpper(_letter);
                }
                BitmapDest = (Bitmap)BitmapSource.Clone();
                if (_letter >= ' ') {
                    using (Graphics gfx = Graphics.FromImage(BitmapDest)) {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(240, 240, 240))) {
                            gfx.FillRectangle(brush, 0, 0, BitmapDest.Width, BitmapDest.Height);
                        }
                        gfx.SmoothingMode = SmoothingMode.AntiAlias;
                        gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        gfx.DrawString(_letter.ToString(), FONT, BRUSH, -3, 2);
                    }
                }
            }
        }

        [JsonIgnore]
        public int[] Data { get; set; } = Array.Empty<int>();


        [JsonConstructor]
        public Symbol(Bitmap bitmapSource, int count, int index, char letter) : this(bitmapSource) {
            Count = count;
            Index = index;
            Letter = letter;
        }

        public Symbol(Bitmap bitmapSource) {
            BitmapSource = bitmapSource;
            BitmapDest = (Bitmap)BitmapSource.Clone();
            Data = new int[bitmapSource.Width * bitmapSource.Height];

            for (int y = 0; y < bitmapSource.Height; y++) {
                for (int x = 0; x < bitmapSource.Width; x++) {
                    var color = bitmapSource.GetPixel(x, y);
                    var value = color.R;
                    Data[y * bitmapSource.Width + x] = value;
                }
            }
        }

        public override bool Equals(object? obj) {
            return obj is Symbol symbol &&
                   symbol.Data.SequenceEqual(Data);
        }

        public override int GetHashCode() {
            return ((IStructuralEquatable)Data).GetHashCode(EqualityComparer<int>.Default);
        }
    }
}
