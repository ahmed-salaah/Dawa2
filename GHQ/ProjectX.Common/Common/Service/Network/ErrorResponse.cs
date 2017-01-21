using System;
using System.Collections.Generic;

namespace Service.Network
{
    public class ErrorResponse
    {
        public List<string> ErrorMessages { get; set; }
        public string ErrorMessagesString
        {
            get
            {
                string errors = "";
                if(ErrorMessages==null)
                {
                    return errors;
                }
                foreach (var item in ErrorMessages)
                {
                    errors += string.Format("{0}", item) + Environment.NewLine;
                }
                return errors;
            }
        }
    }

}
