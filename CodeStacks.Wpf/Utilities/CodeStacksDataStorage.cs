﻿using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Xiaowen.CodeStacks.Wpf.Utilities
{
    /// <summary>
    /// 数据存储
    /// </summary>
    public class CodeStacksDataStorage
    {
        /// <summary>
        /// 图片另存为
        /// </summary>
        /// <param name="bitmap"></param>
        public static void ImageSaveAs(BitmapImage bitmap)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "(*.png)|*.png";

                bool? result = sfd.ShowDialog();
                bool b = sfd.OverwritePrompt;

                if (result == true)
                {
                    string path = sfd.FileName;
                    if (!File.Exists(path))
                    {
                        #region old
                        //string extension = Path.GetExtension(path);
                        //string safename = Path.GetFileName(path);
                        ////string _safename = Path.GetFileNameWithoutExtension(path);
                        //string directory = Path.GetDirectoryName(path);

                        //using (Image image = Image.FromStream(bitmap.StreamSource))
                        //{
                        //    MemoryStream stream = new MemoryStream();
                        //    image.Save(stream, ImageFormat.Jpeg);
                        //    image.Dispose();
                        //    File.WriteAllBytes(Path.Combine(directory, safename), stream.GetBuffer());
                        //} 
                        #endregion

                        string safename = Path.GetFileName(path);
                        string directory = Path.GetDirectoryName(path);

                        using (Image image = Image.FromStream(bitmap.StreamSource))
                        {
                            MemoryStream stream = new MemoryStream();
                            image.Save(stream, ImageFormat.Png);
                            image.Dispose();
                            File.WriteAllBytes(Path.Combine(directory, safename), stream.GetBuffer());
                        }
                    }
                    else
                    {
                        #region old 手动录入扩展名
                        string extension = Path.GetExtension(path);
                        string safename = Path.GetFileName(path);
                        string _safename = Path.GetFileNameWithoutExtension(path);
                        string directory = Path.GetDirectoryName(path);

                        File.Copy(path, Path.Combine(directory, _safename + ".copy" + extension));
                        File.Delete(path);

                        using (Image image = Image.FromStream(bitmap.StreamSource))
                        {
                            MemoryStream stream = new MemoryStream();
                            image.Save(stream, ImageFormat.Jpeg);
                            image.Dispose();
                            File.WriteAllBytes(Path.Combine(directory, safename), stream.GetBuffer());
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
