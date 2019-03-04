using System;
using System.Collections.Generic;

namespace MMRando
{

    public partial class ROMFuncs
    {

        private static vec16 ReadVertex(int n)
        {
            vec16 v = new vec16();
            return v;
        }

        private static void GetTriangleData(short[] verts)
        {
            CollisionTri T = new CollisionTri();

            T.v1 = ReadVertex(verts[0]);
            T.v2 = ReadVertex(verts[1]);
            T.v3 = ReadVertex(verts[2]);
            vecf32 AB = Subtract(T.v2, T.v1);
            vecf32 BC = Subtract(T.v3, T.v2);
            T.u_n = Normalise(CrossProduct(AB, BC));
            T.d = PlaneDist(T.u_n, T.v1);
        }

        private static void ReadCollisionTriangles()
        {

        }

        private static void ResetSceneFlagMask()
        {
            WriteToROM(SceneFlagMasks, (uint)0);
            WriteToROM(SceneFlagMasks + 0xC, (uint)0);
        }

        private static void UpdateSceneFlagMask(int num)
        {
            int offset = num >> 3;
            int mod = offset % 16;
            if (mod < 4)
            {
                offset += 8;
            }
            else if (mod < 12)
            {
                offset -= 4;
            };
            int bit = 1 << (num & 7);
            int f = AddrToFile((uint)SceneFlagMasks);
            CheckCompressed(f);
            int addr = SceneFlagMasks - MMFileList[f].Addr + offset;
            MMFileList[f].Data[addr] |= (byte)bit;
        }

        private static void ReadSceneTable()
        {
            SceneList = new List<Scene>();
            int f = AddrToFile((uint)SceneTable);
            CheckCompressed(f);
            int _SceneTable = SceneTable - MMFileList[f].Addr;
            int i = 0;
            while (true)
            {
                Scene s = new Scene();
                uint saddr = Arr_ReadU32(MMFileList[f].Data, _SceneTable + i);
                if (saddr > 0x4000000)
                {
                    break;
                };
                if (saddr != 0)
                {
                    s.File = AddrToFile(saddr);
                    s.Number = i >> 4;
                    SceneList.Add(s);
                };
                i += 16;
            };
        }

        private static void GetMaps()
        {
            for (int i = 0; i < SceneList.Count; i++)
            {
                int f = SceneList[i].File;
                CheckCompressed(f);
                int j = 0;
                while (true)
                {
                    byte cmd = MMFileList[f].Data[j];
                    if (cmd == 0x04)
                    {
                        byte mapcount = MMFileList[f].Data[j + 1];
                        int mapsaddr = (int)Arr_ReadU32(MMFileList[f].Data, j + 4) & 0xFFFFFF;
                        for (int k = 0; k < mapcount; k++)
                        {
                            Map m = new Map();
                            m.File = AddrToFile(Arr_ReadU32(MMFileList[f].Data, mapsaddr));
                            SceneList[i].Maps.Add(m);
                            mapsaddr += 8;
                        };
                        break;
                    };
                    if (cmd == 0x14)
                    {
                        break;
                    };
                    j += 8;
                };
            };
        }

        private static void GetMapHeaders()
        {
            for (int i = 0; i < SceneList.Count; i++)
            {
                int maps = SceneList[i].Maps.Count;
                for (int j = 0; j < maps; j++)
                {
                    int f = SceneList[i].Maps[j].File;
                    CheckCompressed(f);
                    int k = 0;
                    int setupsaddr = -1;
                    int nextlowest = -1;
                    while (true)
                    {
                        byte cmd = MMFileList[f].Data[k];
                        if (cmd == 0x18)
                        {
                            setupsaddr = (int)Arr_ReadU32(MMFileList[f].Data, k + 4) & 0xFFFFFF;
                        }
                        else if (cmd == 0x14)
                        {
                            break;
                        }
                        else
                        {
                            if (MMFileList[f].Data[k + 4] == 0x03)
                            {
                                int p = (int)Arr_ReadU32(MMFileList[f].Data, k + 4) & 0xFFFFFF;
                                if (((p < nextlowest) || (nextlowest == -1)) && ((p > setupsaddr) && (setupsaddr != -1)))
                                {
                                    nextlowest = p;
                                };
                            };
                        };
                        k += 8;
                    };
                    if ((setupsaddr == -1) || (nextlowest == -1))
                    {
                        continue;
                    };
                    for (k = setupsaddr; k < nextlowest; k += 4)
                    {
                        byte s = MMFileList[f].Data[k];
                        if (s != 0x03)
                        {
                            break;
                        };
                        int p = (int)Arr_ReadU32(MMFileList[f].Data, k) & 0xFFFFFF;
                        Map m = new Map();
                        m.File = f;
                        m.Header = p;
                        SceneList[i].Maps.Add(m);
                    };
                };
            };
        }

        private static List<Actor> ReadMapActors(byte[] Map, int Addr, int Count)
        {
            List<Actor> Actors = new List<Actor>();
            for (int i = 0; i < Count; i++)
            {
                Actor a = new Actor();
                ushort an = Arr_ReadU16(Map, Addr + (i * 16));
                a.m = an & 0xF000;
                a.n = an & 0x0FFF;
                a.p.x = (short)Arr_ReadU16(Map, Addr + (i * 16) + 2);
                a.p.y = (short)Arr_ReadU16(Map, Addr + (i * 16) + 4);
                a.p.z = (short)Arr_ReadU16(Map, Addr + (i * 16) + 6);
                a.r.x = (short)Arr_ReadU16(Map, Addr + (i * 16) + 8);
                a.r.y = (short)Arr_ReadU16(Map, Addr + (i * 16) + 10);
                a.r.z = (short)Arr_ReadU16(Map, Addr + (i * 16) + 12);
                a.v = Arr_ReadU16(Map, Addr + (i * 16) + 14);
                Actors.Add(a);
            };
            return Actors;
        }

        private static List<int> ReadMapObjects(byte[] Map, int Addr, int Count)
        {
            List<int> Objects = new List<int>();
            for (int i = 0; i < Count; i++)
            {
                Objects.Add(Arr_ReadU16(Map, Addr + (i * 2)));
            };
            return Objects;
        }

        private static void WriteMapActors(byte[] Map, int Addr, List<Actor> Actors)
        {
            for (int i = 0; i < Actors.Count; i++)
            {
                Arr_WriteU16(Map, Addr + (i * 16), (ushort)(Actors[i].m | Actors[i].n));
                Arr_WriteU16(Map, Addr + (i * 16) + 2, (ushort)Actors[i].p.x);
                Arr_WriteU16(Map, Addr + (i * 16) + 4, (ushort)Actors[i].p.y);
                Arr_WriteU16(Map, Addr + (i * 16) + 6, (ushort)Actors[i].p.z);
                Arr_WriteU16(Map, Addr + (i * 16) + 8, (ushort)Actors[i].r.x);
                Arr_WriteU16(Map, Addr + (i * 16) + 10, (ushort)Actors[i].r.y);
                Arr_WriteU16(Map, Addr + (i * 16) + 12, (ushort)Actors[i].r.z);
                Arr_WriteU16(Map, Addr + (i * 16) + 14, (ushort)Actors[i].v);
            };
        }

        private static void WriteMapObjects(byte[] Map, int Addr, List<int> Objects)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                Arr_WriteU16(Map, Addr + (i * 2), (ushort)Objects[i]);
            };
        }

        private static void UpdateMap(Map M)
        {
            WriteMapActors(MMFileList[M.File].Data, M.ActorAddr, M.Actors);
            WriteMapObjects(MMFileList[M.File].Data, M.ObjAddr, M.Objects);
        }

        private static void UpdateScene(Scene S)
        {
            for (int i = 0; i < S.Maps.Count; i++)
            {
                UpdateMap(S.Maps[i]);
            };
        }

        private static void GetActors()
        {
            for (int i = 0; i < SceneList.Count; i++)
            {
                for (int j = 0; j < SceneList[i].Maps.Count; j++)
                {
                    int f = SceneList[i].Maps[j].File;
                    CheckCompressed(f);
                    int k = SceneList[i].Maps[j].Header;
                    while (true)
                    {
                        byte cmd = MMFileList[f].Data[k];
                        if (cmd == 0x01)
                        {
                            byte ActorCount = MMFileList[f].Data[k + 1];
                            int ActorAddr = (int)Arr_ReadU32(MMFileList[f].Data, k + 4) & 0xFFFFFF;
                            SceneList[i].Maps[j].ActorAddr = ActorAddr;
                            SceneList[i].Maps[j].Actors = ReadMapActors(MMFileList[f].Data, ActorAddr, ActorCount);
                        };
                        if (cmd == 0x0B)
                        {
                            byte ObjectCount = MMFileList[f].Data[k + 1];
                            int ObjectAddr = (int)Arr_ReadU32(MMFileList[f].Data, k + 4) & 0xFFFFFF;
                            SceneList[i].Maps[j].ObjAddr = ObjectAddr;
                            SceneList[i].Maps[j].Objects = ReadMapObjects(MMFileList[f].Data, ObjectAddr, ObjectCount);
                        };
                        if (cmd == 0x14)
                        {
                            break;
                        };
                        k += 8;
                    };
                };
            };
        }

    }

}