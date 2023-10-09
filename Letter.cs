
namespace AlienDecryptor {
    public class Letter {
        
        public Symbol Symbol { get; set; }

        public Point Position { get; set; }

        public Letter(Symbol symbol, Point position) {
            Symbol = symbol;
            Position = position;
        }
    }
}
