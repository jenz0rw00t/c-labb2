using System;
using System.Collections.Generic;

namespace Labb1
{
    public class SortedPosList
    {
        private List<Position> list = new List<Position>();

        public int Count() => list.Count;

        public override string ToString() => string.Join(", ", list);
       
        public void Add(Position pos)
        {
            if (list.Count < 1)
            {
                list.Add(pos);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > pos)
                    {
                        list.Insert(i, pos);
                        break;
                    }
                    if (i == list.Count-1)
                    {
                        list.Add(pos);
                        break;
                    }
                }
            }

        }

        public bool Remove(Position pos)
        {
            foreach (var p in list)
            {
                if (p.Equals(pos))
                {
                    list.Remove(p);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList cloneList = new SortedPosList();
            foreach (var pos in list)
            {
                cloneList.Add(pos.Clone());
            }
            return cloneList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            var circleList = Clone();
            foreach (var pos in list)
            {
                if ( (Math.Pow(pos.X - centerPos.X, 2) + Math.Pow(pos.Y - centerPos.Y, 2)) > Math.Pow(radius, 2) ) 
                {
                    circleList.Remove(pos);
                }
            }
            return circleList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            var addedList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++)
            {
                addedList.Add(sp2[i]);
            }
            return addedList;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            var subtractedList = sp1.Clone();
            int i = 0;
            int j = 0;

            while (i < sp1.Count() && j < sp2.Count())
            {
                if ( sp1[i].Equals(sp2[j]) )
                {
                    subtractedList.Remove(sp1[i]);
                    i++;
                    j++;
                }
                else if (sp1[i] < sp2[j])
                {
                    i++;
                }
                else if (sp1[i] > sp2[j])
                {
                    j++;
                }
            }

            return subtractedList;
        }

        public Position this[int i]
        {
            get { return list[i]; }
        }
    }
}