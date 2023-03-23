

using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace mrKrrabs.Models
{
    public class GridImage
    {
        public static Bitmap LoadImage(string filename)
        {
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            return new Bitmap(assets!.Open(new System.Uri("avares://mrKrrabs/Assets/Images/" + filename)));
        }

        private static Bitmap? _treasureUnopened;
        private static Bitmap? _treasureOpened;
        private static Bitmap? _tunnelVisited;
        private static Bitmap? _tunnel;
        private static Bitmap? _dirt;
        private static Bitmap? _krustyCrab;
        private static Bitmap? _player1;
        private static Bitmap? _player2;

        public static Bitmap TreasureUnopened
        {
            get
            {
                _treasureUnopened ??= LoadImage("TreasureUnopened.png");

                return _treasureUnopened;
            }
        }

        public static Bitmap TreasureOpened
        {
            get
            {
                _treasureOpened ??= LoadImage("TreasureOpened.png");

                return _treasureOpened;
            }
        }

        public static Bitmap TunnelVisited
        {
            get
            {
                _tunnelVisited ??= LoadImage("TunnelVisited.png");

                return _tunnelVisited;
            }
        }

        public static Bitmap Tunnel
        {
            get
            {
                _tunnel ??= LoadImage("Tunnel.png");

                return _tunnel;
            }
        }

        public static Bitmap Dirt
        {
            get
            {
                _dirt ??= LoadImage("Dirt.png");

                return _dirt;
            }
        }

        public static Bitmap KrustyKrab
        {
            get
            {
                _krustyCrab ??= LoadImage("KrustyKrab.png");

                return _krustyCrab;
            }
        }

        public static Bitmap Player1
        {
            get
            {
                _player1 ??= LoadImage("Player1.png");

                return _player1;
            }
        }

        public static Bitmap Player2
        {
            get
            {
                _player2 ??= LoadImage("Player2.png");

                return _player2;
            }
        }
    }
}
