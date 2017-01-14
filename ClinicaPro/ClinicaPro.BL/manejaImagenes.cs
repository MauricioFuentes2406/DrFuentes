using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias Añadidas
//using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClinicaPro.BL
{
    public class manejaImagenes
    {
        /// <summary>
        /// Transforma una imagen a en un bitArray, sirve para almancenar la imagen en la BD
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="pictureBoxImg"></param>
        /// <returns></returns>
        public static Byte[] ImagenABitArray(string filename, PictureBox pictureBoxImg)
        {
            Byte[] bytecode;
            if (filename == null && pictureBoxImg.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBoxImg.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            else
            {
                bytecode = File.ReadAllBytes(filename);
            }

            return bytecode;
        }
        /// <summary>
        /// Convierte un arreglo de Bits a aun Imagen 
        /// </summary>
        /// <param name="ImagenABitArray"></param>
        /// <returns></returns>
        public static Image recuperarIMG(Byte[] ImagenABitArray)
        {
            Image image = null;
            MemoryStream ms = new MemoryStream(ImagenABitArray);
            {
                image = Image.FromStream(ms);
            }
            return image;
        }
    }
}
