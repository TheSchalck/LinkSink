using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dk.Schalck.LinkSink.Server.Common.Exception
{
    public class UserExistsException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public UserExistsException(string message) : base(message)
        {

        }
    }
}
