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
    /// <summary>
    /// Controlador para imagenes y PDFs
    /// </summary>
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
        /// Convierte un arreglo de Bytes a aun Imagen 
        /// </summary>
        /// <param name="ByteArrayToImage"></param>
        /// <returns></returns>
        public static Image recuperarIMG(Byte[] ByteArrayToImage)
        {
            Image image = null;
            MemoryStream ms = new MemoryStream(ByteArrayToImage);
            {
                image = Image.FromStream(ms);
            }
            return image;
        }
        /// <summary>
        /// Convierte un List de arreglos de Bytes en Imagenes
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        public static List<Image> recuperarIMG(List<Byte[]> List)
        {
            try
            {
                if (List.Count > 0)
                {
                    List<Image> images = new List<Image>();
                    foreach (var ByteArray in List)
                    {
                        images.Add(recuperarIMG(ByteArray));
                    }
                    return images;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al convertir las el vector de bytes a Images \n"
                                + ex.InnerException.ToString());
                return null;
            }
            
        }
    }
}
