﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using teaCRM.Dao.Impl;
using teaCRM.Model;

namespace teaCRM.Dao.TreeHelpers
{
    public class DepartmentTreeHelper
    {
        #region 获取父类集合

        private static IList<DepartmentTree> returnParentTree()
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                List<DepartmentTree> trees;
                trees = new SysDepartmentDao().GetModelList(db)
                    .Where(d => d.ParentId == 0)
                    .Select(d => new DepartmentTree() {ModuleID = d.Id, ParentID = d.ParentId, ModuleName = d.DepName})
                    .ToList();
                return trees;
            }
        }

        #endregion

        #region 判断分类是否有子类

        /// <summary>
        /// 判断分类是否有子类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsHaveChild(int id)
        {
            bool flag = new SysDepartmentDao().Exists(id);
            return flag;
        }

        #endregion

        #region 根据id获取子类

        /// <summary>
        /// 根据id获取子类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static IList<DepartmentTree> GetChild(int id)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var childTrees = new SysDepartmentDao().GetModelList(db)
                    .Where(d => d.ParentId== id)
                    .Select(d => new DepartmentTree() {ModuleID = d.Id, ParentID = d.ParentId, ModuleName = d.DepName})
                    .ToList();
                return childTrees;
            }
        }

        #endregion

        #region 获取json

        /// <summary>
        /// 获取json
        /// </summary>
        /// <returns></returns>
        public static string GetJson()
        {
            string json = "[";
            IList<DepartmentTree> trees = returnParentTree();
            foreach (DepartmentTree tree in trees)
            {
                if (tree != trees[trees.Count - 1])
                {
                    json += GetJsonByModel(tree) + ",";
                }
                else
                {
                    json += GetJsonByModel(tree);
                }
            }
            json += "]";
            //去除空子树
            json = json.Replace(",\"children\":[]","");
            return json;
        }

        #endregion

        #region 根据模型生成json

        /// <summary>
        /// 根据模型生成json
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static string GetJsonByModel(DepartmentTree tree)
        {
            string json = "";
            bool flag = IsHaveChild(tree.ModuleID);
            json = "{"
                   + "\"id\":\"" + tree.ModuleID + "\","
                   + "\"pid\":\"" + tree.ParentID + "\","
                //+ "\"path\":\"" + tree.ModulePath + "\","
                   + "\"text\":\"" + tree.ModuleName + "\",";

            if (flag)
            {
                json += "\"children\":";
                IList<DepartmentTree> childTrees = GetChild(tree.ModuleID);

                json += "[";
                foreach (DepartmentTree childTree in childTrees)
                {
                    if (tree != childTrees[childTrees.Count - 1])
                    {
                        json += GetJsonByModel(childTree) + ",";
                    }
                    else
                    {
                        json += GetJsonByModel(childTree);
                    }
                }
                if (json.EndsWith(","))
                {
                    json=json.TrimEnd(',');
                }
                json += "]";
            }
            else
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "}";


            return json;
        }

        #endregion
    }
}