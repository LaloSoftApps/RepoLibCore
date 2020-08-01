using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Libs
{
    public class Compress
    {
        public string CompressFile { get; set; }

        public Boolean FileZip(string SourceFile) {
            FileInfo oCompressfile = new FileInfo(CompressFile);
            FileInfo oSourceFile = new FileInfo(SourceFile);

            if (!oSourceFile.Exists)
            {
                throw new Exception($"El Archivo [{oSourceFile.FullName}] no Existe.");
            }

            
            if (!oCompressfile.Exists)
            {
                ZipArchive zip = ZipFile.Open(oCompressfile.FullName, ZipArchiveMode.Create);
                zip.CreateEntryFromFile(oSourceFile.FullName, oSourceFile.Name);
                zip.Dispose();
            }
            else
            {
                ZipArchive zip = ZipFile.Open(oCompressfile.FullName, ZipArchiveMode.Update);
                ZipArchiveEntry oldEntry = zip.GetEntry(oSourceFile.Name);
                if (oldEntry != null) oldEntry.Delete();
                zip.CreateEntryFromFile(oSourceFile.FullName,oSourceFile.Name);
                zip.Dispose();
            }
            



            return true;
        }

        public Boolean FileUnzip(string DestinationFolder)
        {
            FileInfo oCompressfile = new FileInfo(CompressFile);
            DirectoryInfo oDestinationFolder = new DirectoryInfo(DestinationFolder);

            if (!oCompressfile.Exists)
            {
                throw new Exception($"El Archivo [{oCompressfile.FullName}] no Existe.");
            }

            ZipFile.ExtractToDirectory(oCompressfile.FullName, oDestinationFolder.FullName,true);
            
            return true;
        }

        public List<string> FilesList()
        {
            FileInfo oCompressfile = new FileInfo(CompressFile);

            if (!oCompressfile.Exists)
            {
                throw new Exception($"El Archivo [{oCompressfile.FullName}] no Existe.");
            }

            ZipArchive zip = ZipFile.OpenRead(oCompressfile.FullName);

            List<string> List = new List<string>();
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                List.Add(entry.FullName);
            }

            return List;
        }
    }
}
