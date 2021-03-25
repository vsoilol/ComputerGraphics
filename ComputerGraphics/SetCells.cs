using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphics
{
    static class SetCells
    {
        public static List<Bitmap> Bitmaps { get; set; } = new List<Bitmap>();

        static SetCells()
        {
            SetBitmap();

            SetBitmap1();
            SetBitmap2();
            SetBitmap3(); 
            SetBitmap4();
            SetBitmap5();
            SetBitmap6();
            SetBitmap7(); 
            SetBitmap8();
            SetBitmap9();
            SetBitmap10();
            SetBitmap11();
            SetBitmap12();

            SetBitmap13();
            SetBitmap14();
            SetBitmap15();
            SetBitmap16();
            SetBitmap17();
            SetBitmap18();
            SetBitmap19();
            SetBitmap20();
            SetBitmap21();
            SetBitmap22();
            SetBitmap23();
            SetBitmap24();
            SetBitmap25();
        }

        private static void SetBitmap()
        {
            for (int i = 0; i < 26; i++)
            {
                Bitmaps.Add(new Bitmap(5, 5));

                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        Bitmaps[i].SetPixel(x, y, Color.White);
                    }
                }
            }
        }

        private static void SetBitmap1()
        {
            for (int i = 1; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(0, 4, Color.Black);
            }
        }

        private static void SetBitmap2()
        {
            for (int i = 2; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(1, 1, Color.Black);
            }
        }

        private static void SetBitmap3()
        {
            for (int i = 3; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(4, 2, Color.Black);
            }
        }

        private static void SetBitmap4()
        {
            for (int i = 4; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(3, 0, Color.Black);
            }
        }

        private static void SetBitmap5()
        {
            for (int i = 5; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(2, 3, Color.Black);
            }
        }

        private static void SetBitmap6()
        {
            for (int i = 6; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(4, 4, Color.Black);
            }
        }

        private static void SetBitmap7()
        {
            for (int i = 7; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(1, 2, Color.Black);
            }
        }

        private static void SetBitmap8()
        {
            for (int i = 8; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(4, 0, Color.Black);
            }
        }

        private static void SetBitmap9()
        {
            for (int i = 9; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(0, 2, Color.Black);
            }
        }

        private static void SetBitmap10()
        {
            for (int i = 10; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(3, 4, Color.Black);
            }
        }

        private static void SetBitmap11()
        {
            for (int i = 11; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(3, 1, Color.Black);
            }
        }

        private static void SetBitmap12()
        {
            for (int i = 12; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(0, 3, Color.Black);
            }
        }

        private static void SetBitmap13()
        {
            for (int i = 13; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(0, 0, Color.Black);
            }
        }

        private static void SetBitmap14()
        {
            for (int i = 14; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(3, 2, Color.Black);
            }
        }

        private static void SetBitmap15()
        {
            for (int i = 15; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(2, 0, Color.Black);
            }
        }

        private static void SetBitmap16()
        {
            for (int i = 16; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(1, 4, Color.Black);
            }
        }

        private static void SetBitmap17()
        {
            for (int i = 17; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(2, 2, Color.Black);
            }
        }

        private static void SetBitmap18()
        {
            for (int i = 18; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(3, 3, Color.Black);
            }
        }

        private static void SetBitmap19()
        {
            for (int i = 19; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(2, 1, Color.Black);
            }
        }

        private static void SetBitmap20()
        {
            for (int i = 20; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(0, 1, Color.Black);
            }
        }

        private static void SetBitmap21()
        {
            for (int i = 21; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(2, 4, Color.Black);
            }
        }

        private static void SetBitmap22()
        {
            for (int i = 22; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(4, 3, Color.Black);
            }
        }

        private static void SetBitmap23()
        {
            for (int i = 23; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(1, 0, Color.Black);
            }
        }

        private static void SetBitmap24()
        {
            for (int i = 24; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(4, 1, Color.Black);
            }
        }

        private static void SetBitmap25()
        {
            for (int i = 25; i < Bitmaps.Count; i++)
            {
                Bitmaps[i].SetPixel(1, 3, Color.Black);
            }
        }
    }
}
