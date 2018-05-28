using System;

namespace Moway.Radio
{
    public class RadioException:Exception
    {
        public RadioException(string message)
            : base(message)
        {
        }
    }
}
