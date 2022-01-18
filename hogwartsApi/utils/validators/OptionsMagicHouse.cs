using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace hogwartsApi
{
    ///<summary>
    ///Validador de casas magicas
    ///</summary>
    public class OptionsMagicHouse : ValidationAttribute
    {

        public OptionsMagicHouse()
        {
        }

        public override bool IsValid(object value)
        {
            //string strValue = value as string;
            //if (!string.IsNullOrEmpty(strValue))
            //{
            //    int len = strValue.Length;
            //    return len >= this.Minimum && len <= this.Maximum;
            //}
            bool success = Enum.IsDefined(typeof(MagicHouse), value);

            return success;
        }
    }
}