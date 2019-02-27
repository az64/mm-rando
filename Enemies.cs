using System;
using System.Collections.Generic;
using System.Linq;

namespace MMRando
{

    public partial class ROMFuncs
    {

        private class Enemy
        {
            public int Actor = new int();
            public int Object = new int();
            public int ObjectSize = new int();
            public List<int> Variables = new List<int>();
            public int Type = new int();
            public int Stationary = new int();
            public List<int> SceneExclude = new List<int>();
        }

        private class ValueSwap
        {
            public int OldV = new int();
            public int NewV = new int();
        }

        static List<Enemy> Enemies;

        private static void GetEnemyList()
        {
            Enemies = new List<Enemy>();
            string[] lines = Properties.Resources.ENEMIES.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int i = 0;
            while (i < lines.Length)
            {
                if (lines[i].StartsWith("-"))
                {
                    i++;
                    continue;
                };
                Enemy e = new Enemy();
                e.Actor = Convert.ToInt32(lines[i], 16);
                e.Object = Convert.ToInt32(lines[i + 1], 16);
                e.ObjectSize = GetObjSize(e.Object);
                string[] varlist = lines[i + 2].Split(',');
                for (int j = 0; j <  varlist.Length; j++)
                {
                    e.Variables.Add(Convert.ToInt32(varlist[j], 16));
                };
                e.Type = Convert.ToInt32(lines[i + 3], 16);
                e.Stationary = Convert.ToInt32(lines[i + 4], 16);
                if (lines[i + 5] != "")
                {
                    string[] selist = lines[i + 5].Split(',');
                    for (int j = 0; j < selist.Length; j++)
                    {
                        e.SceneExclude.Add(Convert.ToInt32(selist[j], 16));
                    };
                };
                Enemies.Add(e);
                i += 6;
            };
        }

        private static List<int> GetSceneEnemyActors(Scene S)
        {
            List<int> ActorList = new List<int>();
            for (int i = 0; i < S.Maps.Count; i++)
            {
                for (int j = 0; j < S.Maps[i].Actors.Count; j++)
                {
                    int k = Enemies.FindIndex(u => u.Actor == S.Maps[i].Actors[j].n);
                    if (k != -1)
                    {
                        if (!Enemies[k].SceneExclude.Contains(S.Number))
                        {
                            ActorList.Add(Enemies[k].Actor);
                        };
                    };
                };
            };
            return ActorList;
        }

        private static List<int> GetSceneEnemyObjects(Scene S)
        {
            List<int> ObjList = new List<int>();
            for (int i = 0; i < S.Maps.Count; i++)
            {
                for (int j = 0; j < S.Maps[i].Objects.Count; j++)
                {
                    int k = Enemies.FindIndex(u => u.Object == S.Maps[i].Objects[j]);
                    if (k != -1)
                    {
                        if (!ObjList.Contains(Enemies[k].Object))
                        {
                            if (!Enemies[k].SceneExclude.Contains(S.Number))
                            {
                                ObjList.Add(Enemies[k].Object);
                            };
                        };
                    };
                };
            };
            return ObjList;
        }

        private static void SetSceneEnemyActors(Scene S, List<ValueSwap[]> A)
        {
            for (int i = 0; i < S.Maps.Count; i++)
            {
                for (int j = 0; j < S.Maps[i].Actors.Count; j++)
                {
                    int k = A.FindIndex(u => u[0].OldV == S.Maps[i].Actors[j].n);
                    if (k != -1)
                    {
                        S.Maps[i].Actors[j].n = A[k][0].NewV;
                        S.Maps[i].Actors[j].v = A[k][1].NewV;
                        A.RemoveAt(k);
                    };
                };
            };
        }

        private static void SetSceneEnemyObjects(Scene S, List<ValueSwap> O)
        {
            for (int i = 0; i < S.Maps.Count; i++)
            {
                for (int j = 0; j < S.Maps[i].Objects.Count; j++)
                {
                    int k = O.FindIndex(u => u.OldV == S.Maps[i].Objects[j]);
                    if (k != -1)
                    {
                        S.Maps[i].Objects[j] = O[k].NewV;
                    };
                };
            };
        }

        private static List<Enemy> GetMatchPool(List<Enemy> Actors, Random R)
        {
            List<Enemy> Pool = new List<Enemy>();
            for (int i = 0; i < Actors.Count; i++)
            {
                Enemy E = Enemies.Find(u => u.Actor == Actors[i].Actor);
                for (int j = 0; j < Enemies.Count; j++)
                {
                    if ((Enemies[j].Type == E.Type) && (Enemies[j].Stationary == E.Stationary))
                    {
                        if (!Pool.Contains(Enemies[j]))
                        {
                            Pool.Add(Enemies[j]);
                        };
                    }
                    else if ((Enemies[j].Type == E.Type) && (R.Next(5) == 0))
                    {
                        if (!Pool.Contains(Enemies[j]))
                        {
                            Pool.Add(Enemies[j]);
                        };
                    };
                };
            };
            return Pool;
        }

        private static void SwapSceneEnemies(Scene S, Random R)
        {
            List<int> Actors = GetSceneEnemyActors(S);
            if (Actors.Count == 0)
            {
                return;
            };
            List<int> Objects = GetSceneEnemyObjects(S);
            if (Objects.Count == 0)
            {
                return;
            };
            // if actor doesn't exist but object does, probably spawned by something else
            List<int> ObjRemove = new List<int>();
            foreach (int o in Objects)
            {
                List<Enemy> ObjectMatch = Enemies.FindAll(u => u.Object == o);
                bool exists = false;
                for (int i = 0; i < ObjectMatch.Count; i++)
                {
                    exists |= Actors.Contains(ObjectMatch[i].Actor);
                };
                if (!exists)
                {
                    ObjRemove.Add(o); ;
                };
            };
            foreach (int o in ObjRemove)
            {
                Objects.Remove(o);
            };
            List<ValueSwap[]> ActorsUpdate = new List<ValueSwap[]>();
            List<ValueSwap> ObjsUpdate;
            List<List<Enemy>> Updates;
            List<List<Enemy>> Matches;
            while (true)
            {
                ObjsUpdate = new List<ValueSwap>();
                Updates = new List<List<Enemy>>();
                Matches = new List<List<Enemy>>();
                int oldsize = 0;
                int newsize = 0;
                for (int i = 0; i < Objects.Count; i++)
                {
                    Updates.Add(Enemies.FindAll(u => ((u.Object == Objects[i]) && (Actors.Contains(u.Actor)))));
                    Matches.Add(GetMatchPool(Updates[i], R));
                    int k = R.Next(Matches[i].Count);
                    int newobj = Matches[i][k].Object;
                    newsize += Matches[i][k].ObjectSize;
                    oldsize += Updates[i][0].ObjectSize;
                    ValueSwap NewObject = new ValueSwap();
                    NewObject.OldV = Objects[i];
                    NewObject.NewV = newobj;
                    ObjsUpdate.Add(NewObject);
                };
                if (newsize <= oldsize)
                {
                    //this should take into account map/scene size and size of all loaded actors...
                    //not really accurate but *should* work for now to prevent crashing
                    break;
                };
            };
            for (int i = 0; i < ObjsUpdate.Count; i++)
            {
                int j = 0;
                while (j != Actors.Count)
                {
                    Enemy Old = Updates[i].Find(u => u.Actor == Actors[j]);
                    if (Old != null)
                    {
                        List<Enemy> SubMatches = Matches[i].FindAll(u => u.Object == ObjsUpdate[i].NewV);
                        int l;
                        while (true)
                        {
                            l = R.Next(SubMatches.Count);
                            if ((Old.Type == SubMatches[l].Type) && (Old.Stationary == SubMatches[l].Stationary))
                            {
                                break;
                            }
                            else
                            {
                                if ((Old.Type == SubMatches[l].Type) && (R.Next(5) == 0))
                                {
                                    break;
                                };
                            };
                            if (SubMatches.FindIndex(u => u.Type == Old.Type) == -1)
                            {
                                break;
                            };
                        };
                        ValueSwap NewActor = new ValueSwap();
                        NewActor.OldV = Actors[j];
                        NewActor.NewV = SubMatches[l].Actor;
                        ValueSwap NewVar = new ValueSwap();
                        NewVar.NewV = SubMatches[l].Variables[R.Next(SubMatches[l].Variables.Count)];
                        ActorsUpdate.Add(new ValueSwap[] { NewActor, NewVar });
                        Actors.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    };
                };
            };
            SetSceneEnemyActors(S, ActorsUpdate);
            SetSceneEnemyObjects(S, ObjsUpdate);
            UpdateScene(S);
        }

        public static void ShuffleEnemies(Random R)
        {
            int[] SceneSkip = new int[] { 0x08, 0x20, 0x24, 0x4F, 0x69 };
            GetEnemyList();
            ReadSceneTable();
            GetMaps();
            GetMapHeaders();
            GetActors();
            for (int i = 0; i < SceneList.Count; i++)
            {
                if (!SceneSkip.Contains(SceneList[i].Number))
                {
                    SwapSceneEnemies(SceneList[i], R);
                };
            };
        }

    }

}