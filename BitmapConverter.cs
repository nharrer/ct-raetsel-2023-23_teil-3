using System.Text.Json.Serialization;
using System.Text.Json;

namespace AlienDecryptor {
    public class BitmapConverter : JsonConverter<Bitmap> {

        public override Bitmap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var json = reader.GetString();
            if (json != null) {
                var bitmapData = JsonSerializer.Deserialize(json, typeof(BitmapData)) as BitmapData;
                if (bitmapData != null) {
                    var bmp = new Bitmap(bitmapData.Width, bitmapData.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    int idx = 0;
                    for (int y = 0; y < bmp.Height; y++) {
                        for (int x = 0; x < bmp.Width; x++) {
                            int val = bitmapData.Pixel[idx++];
                            var color = Color.FromArgb(255, val, val, val);
                            bmp.SetPixel(x, y, color);
                        }
                    }
                    return bmp;
                }
            }
            throw new Exception("Invalid Data deserialzing a Bitmap");
        }

        public override void Write(Utf8JsonWriter writer, Bitmap bmp, JsonSerializerOptions options) {
            int[] data = new int[bmp.Width * bmp.Height];

            for (int y = 0; y < bmp.Height; y++) {
                for (int x = 0; x < bmp.Width; x++) {
                    var color = bmp.GetPixel(x, y);
                    var value = color.R;
                    data[y * bmp.Width + x] = value;
                }
            }

            var bitmapData = new BitmapData() {
                Width = bmp.Width,
                Height = bmp.Height,
                Pixel = data
            };

            writer.WriteStringValue(JsonSerializer.Serialize(bitmapData));
        }

        private class BitmapData {
            public int Width { get; set; }
            public int Height { get; set; }
            public int[] Pixel { get; set; } = Array.Empty<int>();

            public BitmapData() {
            }
        }
    }
}