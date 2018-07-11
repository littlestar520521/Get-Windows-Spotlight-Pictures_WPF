using System;
using System.IO;

namespace Get_Windows_Spotlight_Pictures_WPF
{
    /// <summary>
    /// 文件操作函数集
    /// </summary>
    class FilesOperating
    {
        /// <summary>
        /// 获取满足大小要求的文件集合
        /// </summary>
        /// <param name="files">待检测的文件集合</param>
        /// <param name="fileNum">待检测文件数量</param>Num
        /// <param name="size">按此大小筛选，单位KB</param>
        /// <returns></returns>
        public string[] GetFilesBySize(string[] files, int fileNum, int size)
        {
            string[] newFiles = new string[fileNum];
            int j = 0;
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(files[i]);
                    if (fileInfo.Length >= size * 1024) 
                    {
                        newFiles[j] = files[i];
                        j++;
                    }
                }
                if (j > 0)
                {
                    string[] newFiles2 = new string[j];
                    for (int k = 0; k < j; k++)
                    {
                        newFiles2[k] = newFiles[k];
                    }
                    return newFiles2;
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 批量复制文件并修改扩展名为.jpg
        /// </summary>
        /// <param name="files">待处理文件集合</param>
        /// <param name="newPath">复制目标路径</param>
        /// <returns></returns>
        public string[] CopyJPGFiles(string[] files, string newPath)
        {
            string[] newFiles = new string[files.Length];
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (File.Exists(files[i]))
                    {
                        string shortFileName = Path.GetFileNameWithoutExtension(files[i]);
                        File.Copy(files[i], newPath + @"\" + shortFileName + ".jpg", true);
                        newFiles[i] = newPath + @"\" + shortFileName + ".jpg";
                    }
                }
                return newFiles;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
