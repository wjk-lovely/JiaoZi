using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Verify
    {
        public static byte[] CreateValidateGraphic(out string Code, int CodeLength, int Width, int Height, int FontSize)
        {
            string sCode = string.Empty;
            //颜色
            Color[] oColors =
            {
                Color.Black,
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Orange,
                Color.Brown,
                Color.DarkBlue
            };
            //字体
            string[] oFontNames = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiu", "Impact" };
            //验证码中的元素
            char[] oCharacter =
            {
                '0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','J','K', 'L','M','N','P','R','S','T','W','X','Y'
            };
            Random oRand = new Random();
            Bitmap oBmp = null;
            Graphics oGraphics = null;
            int N = 0;
            Point oPoint1 = default(Point);
            Point oPoint2 = default(Point);
            string sFontName = null;
            Font oFont = null;
            Color oColor = default(Color);
            //生成验证码
            for (N = 0; N <= CodeLength - 1; N++)
            {
                sCode += oCharacter[oRand.Next(oCharacter.Length)];
            }
            oBmp = new Bitmap(Width, Height);
            oGraphics = Graphics.FromImage(oBmp);
            oGraphics.Clear(Color.White);
            //画线
            try
            {
                for (N = 0; N <= 4; N++)
                {
                    oPoint1.X = oRand.Next(Width);
                    oPoint1.Y = oRand.Next(Height);
                    oPoint2.X = oRand.Next(Width);
                    oPoint2.Y = oRand.Next(Height);
                    oColor = oColors[oRand.Next(oColors.Length)];
                    oGraphics.DrawLine(new Pen(oColor), oPoint1, oPoint2);
                }
                float spaceWidth = 0, dotX = 0, dotY = 0;
                if (CodeLength != 0)
                {
                    spaceWidth = (Width - FontSize * CodeLength - 10) / CodeLength;
                }
                //画验证码
                for (N = 0; N <= sCode.Length - 1; N++)
                {
                    sFontName = oFontNames[oRand.Next(oFontNames.Length)];
                    oFont = new Font(sFontName, FontSize, FontStyle.Italic);
                    oColor = oColors[oRand.Next(oColors.Length)];
                    dotY = (Height - oFont.Height) / 2 + 2;//中心下移2像素
                    dotX = Convert.ToSingle(N) * FontSize + (N + 1) * spaceWidth;
                    oGraphics.DrawString(sCode[N].ToString(), oFont, new SolidBrush(oColor), dotX, dotY);
                }
                //画点
                for (int i = 0; i <= 30; i++)
                {
                    int x = oRand.Next(oBmp.Width);
                    int y = oRand.Next(oBmp.Height);
                    Color clr = oColors[oRand.Next(oColors.Length)];
                    oBmp.SetPixel(x, y, clr);
                }
                Code = sCode;
                MemoryStream stream = new MemoryStream();
                oBmp.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
            finally
            {
                oGraphics.Dispose();
            }
        }
    }
}