
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using NLite.Reflection;
using teaCRM.Common;
using teaCRM.DBContext;
using teaCRM.Entity;
using System.Linq.Dynamic;

namespace  teaCRM.Dao.Impl
{

    /// <summary>
    /// 自动生成的实现ITCusExpvalue99999Dao接口的Dao类。 2014-09-19 04:25:19 By 唐有炜
    /// </summary>
 public class TCusExpvalue99999DaoImpl:ITCusExpvalue99999Dao
    {

	  #region 读操作


	   /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <returns>返回所有数据总数</returns>
        public int GetCount() 
        {
          using (teaCRMDBContext db=new teaCRMDBContext())
            {
             var models= db.TCusExpvalue99999s;
			 var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.Count();
            }
        }

		
             /// <summary>
        /// 获取数据总数
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据总数</returns>
       public int GetCount(Expression<Func<TCusExpvalue99999, bool>> predicate)
        {
             using (teaCRMDBContext db=new teaCRMDBContext())
            {
             var models= db.TCusExpvalue99999s.Where<TCusExpvalue99999>(predicate);
			 var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.Count();
            }
        }




	    /// <summary>
        /// 获取所有的数据
	    /// </summary>
	    /// <returns>返回所有数据列表</returns>
        public List<TCusExpvalue99999> GetList() 
        {
          using (teaCRMDBContext db=new teaCRMDBContext())
            {
             var models= db.TCusExpvalue99999s;
			  var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.ToList();
            }
        }

		
        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据列表</returns>
       public List<TCusExpvalue99999> GetList(Expression<Func<TCusExpvalue99999, bool>> predicate)
        {
             using (teaCRMDBContext db=new teaCRMDBContext())
            {
             var models= db.TCusExpvalue99999s.Where<TCusExpvalue99999>(predicate);
			   var sqlText = models.GetProperty("SqlText");
             LogHelper.Debug(sqlText.ToString());
			 return models.ToList();
            }
        }

		/// <summary>
        /// 获取指定的单个实体
        /// 如果不存在则返回null
        /// 如果存在多个则抛异常
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>Entity</returns>
        public TCusExpvalue99999 GetEntity(Expression<Func<TCusExpvalue99999, bool>> predicate) 
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                var model =db.TCusExpvalue99999s.Where<TCusExpvalue99999>(predicate);
			    var sqlText = model.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return model.SingleOrDefault();
		    }
        }

		
		
        /// <summary>
        /// 根据条件查询某些字段(LINQ 动态查询)
        /// </summary>
        /// <param name="selector">要查询的字段（格式：new(ID,Name)）</param>
        /// <param name="predicate">筛选条件（id=0）</param>
        /// <returns></returns>
        public IQueryable<Object> GetFields(string selector, string predicate)
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                var model = db.TCusExpvalue99999s.Where(predicate).Select(selector);
                var sqlText = model.GetProperty("SqlText");
                LogHelper.Debug(sqlText.ToString());
                return (IQueryable<object>) model;
            }
        }


		   /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
       public   bool ExistsEntity(Expression<Func<TCusExpvalue99999 , bool>> predicate)
	   {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
               bool status= db.TCusExpvalue99999s.Any(predicate);
               return status;
            }
        }

		

		
	   //查询分页
        public IPagination<TCusExpvalue99999> GetListByPage(int pageIndex, int pageSize, out int rowCount,
            IDictionary<string, teaCRM.Entity.teaCRMEnums.OrderEmum> orders,
            Expression<Func<TCusExpvalue99999, bool>> predicate)
        {
            using (teaCRMDBContext db = new teaCRMDBContext())
            {
                var roles = db.TCusExpvalue99999s.Where(predicate);
                rowCount = roles.Count();
                var prevCount = (pageIndex - 1)*pageSize;
                var models = roles
                    .Skip(prevCount)
                    .Take(pageSize);
                foreach (var order in orders)
                {
                    models = models.OrderBy(String.Format("{0} {1}", order.Key, order.Value));
                }
                var sqlText = models.GetProperty("SqlText");
                LogHelper.Debug("ELINQ Paging:<br/>" + sqlText.ToString());
                return models.ToPagination(pageSize, pageSize, rowCount);
            }
        }


	  

	  //以下是原生Sql方法==============================================================
	  //===========================================================================
	   /// <summary>
        /// 用SQL语句查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="namedParameters">sql参数</param>
        /// <returns>集合</returns>
        public IEnumerable<TCusExpvalue99999> GetListBySql(string sql, dynamic namedParameters)
        {
          using (teaCRMDBContext db=new teaCRMDBContext())
            {
               return db.DbHelper.ExecuteDataTable(sql,namedParameters).ToList<TCusExpvalue99999>();
            }
          
        }
  #endregion


   #region 写操作
		  /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public bool InsertEntity(TCusExpvalue99999 entity)
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
              int rows=  db.TCusExpvalue99999s.Insert(entity);
				 if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       /// <summary>
        /// 删除实体
        /// </summary>
         /// <param name="predicate">Lamda表达式</param>
        public bool DeleteEntity(Expression<Func<TCusExpvalue99999 , bool>> predicate) 
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                TCusExpvalue99999  entity = db.TCusExpvalue99999s.Where(predicate).First();
                int rows=db.TCusExpvalue99999s.Delete(entity);
				 if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
		
		/// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list">实体集合</param>
        public bool DeletesEntity(List<TCusExpvalue99999> list) 
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                //var tran = db.Connection.BeginTransaction();
                try
                {
                    foreach (var item in list)
                    {
                        db.TCusExpvalue99999s.Delete(item);
                    }
                    //tran.Commit();
					return true;
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
					return false;
                    throw new Exception(ex.Message);
                }
            }
        }

         /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public bool UpadateEntity(TCusExpvalue99999 entity)
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
               int rows= db.TCusExpvalue99999s.Update(entity);
			   if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


     
		
		/// <summary>
	     /// 执行Sql
	     /// </summary>
	     /// <param name="sql">Sql语句</param>
	     /// <param name="namedParameters">查询字符串</param>
	     /// <returns></returns>
		public bool ExecuteSql(string sql, dynamic namedParameters = null)
		{
	         using (teaCRMDBContext db = new teaCRMDBContext())
	         {
	             var rows = db.DbHelper.ExecuteNonQuery(sql, namedParameters);
	             if (rows > 0)
	             {
	                 return true;
	             }
	             else
	             {
	                 return false;
	             }
	         }
		}

		  #endregion


	   }
	   }
