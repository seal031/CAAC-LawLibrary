using CAAC_LawLibrary.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.BLL
{
    public class NodeWorker
    {
        public static string buildFromNodeContext(List<Node> list)
        {
            string result = string.Empty;

            return result;
        }

        /// <summary>
        /// 字符串转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ConvertStringToEntity<T>(string str) where T:class
        {
            try
            {
                var result = (T)(JsonConvert.DeserializeObject(str));
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
