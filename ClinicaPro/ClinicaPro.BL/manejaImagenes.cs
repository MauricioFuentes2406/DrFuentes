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
using System.Drawing.Imaging;
using ClinicaPro.General.Constantes;

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

            if (ByteArrayToImage == null) return null;
            try
            {
                Image image = null;
                MemoryStream ms = new MemoryStream(ByteArrayToImage);
                {
                    image = Image.FromStream(ms);
                }
                return image;
            }
            catch (Exception)
            {
                MessageBox.Show( Mensajes.ErrorCargarImagen, Mensajes.Upss_Falto_Algo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }            
           
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
        public static void ConfigurarFileDialogFilter(OpenFileDialog openFileDialog1)
        {
              ImageCodecInfo[] ArrayImageEncoders = ImageCodecInfo.GetImageEncoders();
            string separador = string.Empty;
            openFileDialog1.FileName = "Imagen";

            foreach (var codec in ArrayImageEncoders) 
            {
                string codecName = codec.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                openFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog1.Filter, separador, codecName, codec.FilenameExtension);
                separador = "|";  // En la primera iteracion  debe ir en blanco  | 
            }
            openFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", openFileDialog1.Filter, separador, "All Images", "*.*");

            openFileDialog1.DefaultExt = ".png"; // Default file extension 
        }
    }
}
