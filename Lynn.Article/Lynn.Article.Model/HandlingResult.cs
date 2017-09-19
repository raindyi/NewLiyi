using System;

namespace Lynn.Article.Model
{
    public class HandlingResult
    {
        /// <summary>
        /// Gets or sets handled result,default value is true
        /// </summary>
        public Boolean Successed { get; set; }

        /// <summary>
        /// Gets or sets handled message,default value is Empty
        /// </summary>
        public String Message { get; set; }
        /// <summary>
        /// Gets or sets handled message inner number
        /// </summary>
        public Int32 MsgNumber { get; set; }
        /// <summary>
        /// Gets or sets handled others result,default value is null
        /// </summary>
        public Object Result { get; set; }

        public HandlingResult()
        {
            Successed = true;
            Message = String.Empty;
            Result = null;
        }
    }
}