using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosBusiness
{
    public abstract class Base
    {
        public string ErrorMessage { get; set; }
        public string InfoMessage { get; set; }
        public bool HasErrors { get; set; }
        public virtual void BuildErrorMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Message: {0}", ex.Message));
            sb.AppendLine(string.Format("Message Source: {0}", ex.Source));
            sb.AppendLine(string.Format("Message TargetSite: {0}", ex.TargetSite));
            if (ex.InnerException != null)
            {
                Exception innerEx = ex.InnerException;

                do
                {
                    sb.AppendLine(string.Format("InnerException Message: {0}", innerEx.Message));
                    sb.AppendLine(string.Format("InnerException Source:", innerEx.Source));
                    sb.AppendLine(string.Format("InnerException TargetSite:", innerEx.TargetSite));
                    innerEx = innerEx.InnerException;
                }
                while (innerEx != null);


            }
            ErrorMessage = sb.ToString();
            InfoMessage = "Error Occured, please check ErrorMessage!";
            HasErrors = true;
        }
    }
}
