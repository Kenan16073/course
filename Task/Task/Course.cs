using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Course:ICourse
    {
        public Group[] gp = new Group[0];

        public Group[] AddGroup(Group group)
        {
            Array.Resize(ref gp, gp.Length + 1);
            gp[gp.Length - 1] = group;

            return gp;

        }

        public Group GetGroupByNo(string no)
        {
            foreach (Group item in gp)
            {
                if (item.No == no)
                    return item;
            }
            return null;
        }

        public Group[] GetGroupsByPointRange(int minPoint, int maxPoint)
        {
            Group[] wantedGroups = new Group[0];

            foreach (var item in gp)
            {
                if (item.AvgPoint >= minPoint && item.AvgPoint <= maxPoint)
                {
                    Array.Resize(ref wantedGroups, wantedGroups.Length + 1);
                    wantedGroups[wantedGroups.Length - 1] = item;
                }
            }

            return wantedGroups;
        }

        public Group[] Search(string str)
        {
            Group[] wantedGroups = new Group[0];

            foreach (var gr in gp)
            {
                if (gr.No.Contains(str))
                {
                    Array.Resize(ref wantedGroups, wantedGroups.Length + 1);
                    wantedGroups[wantedGroups.Length - 1] = gr;
                }
            }
            return wantedGroups;
        }
    }
}
