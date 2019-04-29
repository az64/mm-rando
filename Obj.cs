using System;

namespace MMRando
{

    public partial class ROMFuncs
    {

        public static int GetObjSize(int obj)
        {
            int f = GetFileIndexForWriting(ObjTable);
            int basea = ObjTable - MMFileList[f].Addr;
            return (int)(Arr_ReadU32(MMFileList[f].Data, basea + (obj * 8) + 4) - Arr_ReadU32(MMFileList[f].Data, basea + (obj * 8)));
        }

        public static void InsertObj(byte[] obj, int replace)
        {
            int f = GetFileIndexForWriting(ObjTable);
            int basea = ObjTable - MMFileList[f].Addr;
            uint replaceaddr = Arr_ReadU32(MMFileList[f].Data, basea + (replace * 8));
            int objf = MMFileList.FindIndex(u => u.Addr == replaceaddr);
            if (objf == -1)
            {
                return;
            };
            if (obj.Length > (MMFileList[objf].End - MMFileList[objf].Addr))
            {
                MMFile newfile = new MMFile();
                newfile.Addr = MMFileList[MMFileList.Count - 1].End;
                newfile.End = newfile.Addr + obj.Length;
                newfile.IsCompressed = true;
                newfile.WasEdited = true;
                newfile.Data = obj;
                MMFileList[objf].Cmp_Addr = -1;
                MMFileList[objf].Cmp_End = -1;
                MMFileList[objf].Data = null;
                MMFileList[objf].IsCompressed = false;
                MMFileList.Add(newfile);
                Arr_WriteU32(MMFileList[f].Data, basea + (replace * 8), (uint)newfile.Addr);
                Arr_WriteU32(MMFileList[f].Data, basea + (replace * 8) + 4, (uint)newfile.End);
            }
            else
            {
                MMFileList[objf].Data = obj;
                MMFileList[objf].WasEdited = true;
            };
        }

    }

}